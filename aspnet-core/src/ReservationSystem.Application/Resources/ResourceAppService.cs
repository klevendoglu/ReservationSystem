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
    public class ResourceAppService : ApplicationService, IResourceAppService
    {
        private readonly ResourceManager _resourceManager;
        private readonly IRepository<Resource, Guid> _resourceRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ResourceAppService(
            IRepository<Resource, Guid> resourceRepository,
            ResourceManager resourceManager,
            IRepository<AppUser, Guid> userRepository)
        {
            _resourceRepository = resourceRepository;
            _resourceManager = resourceManager;
            _userRepository = userRepository;
        }

        public async Task<ResourceDto> CreateAsync(CreateResourceInputDto input)
        {
            var resource = new Resource(
                    GuidGenerator.Create(),
                    input.Name,
                    input.ManagerId,
                    input.Category,
                    input.ParentId,
                    input.MaxReservationHours,
                    input.Location,
                    input.Serial,
                    input.Image,
                    input.Description
            );

            await _resourceRepository.InsertAsync(resource);
            return ObjectMapper.Map<Resource, ResourceDto>(resource);
        }

        public async Task<ResourceDto> UpdateAsync(UpdateResourceInputDto input)
        {
            var resource = await _resourceRepository.GetAsync(input.Id);

            await _resourceManager.ChangeNameAsync(resource, input.Name);

            if (input.ParentId.HasValue)
            {
                var parentResource = await _resourceRepository.GetAsync(input.ParentId.Value);
                await _resourceManager.AssignParent(resource, parentResource);
            }

            var user = await _userRepository.GetAsync(input.ManagerId);
            await _resourceManager.AssignManager(resource, user);

            resource.Location = input.Location;
            resource.Description = input.Description;
            resource.Image = input.Image;
            resource.Serial = input.Serial;
            resource.Category = input.Category;
            resource.MaxReservationHours = input.MaxReservationHours;

            await _resourceRepository.UpdateAsync(resource);

            return ObjectMapper.Map<Resource, ResourceDto>(resource);
        }

        public async Task<ResourceDto> GetResourceAsync(Guid id)
        {
            return ObjectMapper.Map<Resource, ResourceDto>(await _resourceRepository.GetAsync(id));
        }

        public async Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourcesInput input)
        {
            var resourceDtos = ObjectMapper.Map<List<Resource>, List<ResourceDto>>(await _resourceRepository.GetListAsync());
            var totalCount = await _resourceRepository.GetCountAsync();
            return new PagedResultDto<ResourceDto>(totalCount, resourceDtos);
        }

        public Task DeleteResource(Guid id)
        {
            throw new NotImplementedException();
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
