using Microsoft.AspNetCore.Authorization;
using ReservationSystem.Permissions;
using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Resources.Dtos;
using ReservationSystem.Resources.Dtos.Resource;
using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace ReservationSystem.Resources
{
    [Authorize(ReservationSystemPermissions.Resources.Default)]
    public class ResourceAppService : CrudAppService<
            Resource, //The Resource entity
            ResourceDto, //Used to show resources
            Guid, //Primary key of the resource entity
            GetResourcesInput, //Used for paging/sorting
            CreateResourceInputDto, //Used for creating entity
            UpdateResourceInputDto>, IResourceAppService
    {
        private readonly ResourceManager _resourceManager;
        private readonly IRepository<Resource, Guid> _resourceRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public ResourceAppService(
            IRepository<Resource, Guid> repository,
            ResourceManager resourceManager,
            IRepository<AppUser, Guid> userRepository,
            IAsyncQueryableExecuter asyncExecuter
            )
            : base(repository)
        {
            _resourceRepository = repository;
            _resourceManager = resourceManager;
            _userRepository = userRepository;

            _asyncExecuter = asyncExecuter;

            GetPolicyName = ReservationSystemPermissions.Resources.Default;
            GetListPolicyName = ReservationSystemPermissions.Resources.Default;
            CreatePolicyName = ReservationSystemPermissions.Resources.Create;
            UpdatePolicyName = ReservationSystemPermissions.Resources.Edit;
            DeletePolicyName = ReservationSystemPermissions.Resources.Create;
        }

        public override async Task<ResourceDto> CreateAsync(CreateResourceInputDto input)
        {
            var resource = await _resourceManager.CreateAsync(
                    input.Name,
                    input.ManagerId,
                    input.Category,
                    input.MaxReservationHours,
                    input.ParentId,
                    input.Location,
                    input.Serial,
                    input.Image,
                    input.Description
            );

            await _resourceRepository.InsertAsync(resource);
            return ObjectMapper.Map<Resource, ResourceDto>(resource);
        }

        public override async Task<ResourceDto> UpdateAsync(Guid id, UpdateResourceInputDto input)
        {
            var resource = await _resourceRepository.GetAsync(id);

            await _resourceManager.ChangeNameAsync(resource, input.Name);

            if (input.ParentId.HasValue)
            {
                var parentResource = await _resourceRepository.GetAsync(input.ParentId.Value);
                await _resourceManager.AssignParentAsync(resource, parentResource);
            }

            var user = await _userRepository.GetAsync(input.ManagerId);
            await _resourceManager.AssignManagerAsync(resource, user);

            resource.Location = input.Location;
            resource.Description = input.Description;
            resource.Image = input.Image;
            resource.Serial = input.Serial;
            resource.Category = input.Category;
            resource.MaxReservationHours = input.MaxReservationHours;

            await _resourceRepository.UpdateAsync(resource);

            return ObjectMapper.Map<Resource, ResourceDto>(resource);
        }

        public override async Task<ResourceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Resource, ResourceDto>(await _resourceRepository.GetAsync(id));
        }

        public override async Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourcesInput input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Resource.Name);
            }

            var resources = await _asyncExecuter.ToListAsync(_resourceRepository
                    .WhereIf(input.ResourceId.HasValue, t => t.Id == input.ResourceId.Value)
                    .WhereIf(input.ParentId.HasValue, t => t.ParentId == input.ParentId)
                    .WhereIf(input.Category.HasValue, t => t.Category == (int)input.Category)
                    .WhereIf(input.OnlyChildren, t => t.ParentId != null)
                    .WhereIf(input.OnlyParents, t => t.ParentId == null)
                    .WhereIf(!string.IsNullOrEmpty(input.Filter), t => t.Name.Contains(input.Filter) || t.Description.Contains(input.Filter) || t.Serial.Contains(input.Filter))
                );

            var resourceDtos = ObjectMapper.Map<List<Resource>, List<ResourceDto>>(resources);
            var totalCount = resources.Count;
            return new PagedResultDto<ResourceDto>(totalCount, resourceDtos);
        }

        public async Task<ListResultDto<UserDto>> GetResourceManagers()
        {
            var users = await _userRepository.GetListAsync();

            return new ListResultDto<UserDto>(
                ObjectMapper.Map<List<AppUser>, List<UserDto>>(users)
            );
        }

    }
}
