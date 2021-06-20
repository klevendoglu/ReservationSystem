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

namespace ReservationSystem.Resources
{
    [Authorize(ReservationSystemPermissions.Resources.Default)]
    public class ResourceAppService : CrudAppService<
            Resource, //The Resource entity
            ResourceDto, //Used to show resources
            Guid, //Primary key of the resource entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateResourceInputDto, //Used for creating entity
            UpdateResourceInputDto>, IResourceAppService
    {
        private readonly ResourceManager _resourceManager;
        private readonly IRepository<Resource, Guid> _resourceRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ResourceAppService(
            IRepository<Resource, Guid> repository,
            ResourceManager resourceManager,
            IRepository<AppUser, Guid> userRepository)
            : base(repository)
        {
            _resourceRepository = repository;
            _resourceManager = resourceManager;
            _userRepository = userRepository;

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

        public override async Task<PagedResultDto<ResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Resource.Name);
            }

            var resourceDtos = ObjectMapper.Map<List<Resource>, List<ResourceDto>>(await _resourceRepository.GetListAsync());
            var totalCount = await _resourceRepository.GetCountAsync();
            return new PagedResultDto<ResourceDto>(totalCount, resourceDtos);
        }

        public void CheckReservationHours(CreateReservationItemInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceDto> CheckResourceAvailability(CreateReservationItemInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<UserDto>> GetResourceManagers()
        {
            throw new NotImplementedException();
        }

        public Task<ResourceScheduleOutputDto> GetResourceSchedule(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ResourceDto>> GetResourcesLibrary(GetResourcesInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ResourceDto>> GetResourcesMeetingRoom(GetResourcesInput input)
        {
            throw new NotImplementedException();
        }
        public Task<PagedResultDto<ResourceDto>> GetResourcesStudio(GetResourcesInput input)
        {
            throw new NotImplementedException();
        }
    }
}
