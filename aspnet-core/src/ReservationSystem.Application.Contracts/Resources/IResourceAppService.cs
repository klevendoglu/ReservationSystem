using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Resources.Dtos;
using ReservationSystem.Resources.Dtos.Resource;
using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ReservationSystem.Resources
{
    public interface IResourceAppService : IApplicationService
    {
        Task<ResourceDto> CreateAsync(CreateResourceInputDto input);
        Task<ResourceDto> UpdateAsync(UpdateResourceInputDto input);
        Task DeleteResource(Guid id);
        Task<ResourceDto> GetResourceAsync(Guid id);
        Task<ResourceDto> CheckResourceAvailability(CreateReservationItemInputDto input);
        void CheckReservationHours(CreateReservationItemInputDto input);
        Task<ResourceScheduleOutputDto> GetResourceSchedule(Guid id);

        Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourcesInput input);
        Task<PagedResultDto<ResourceDto>> GetResourcesStudio(GetResourcesInput input);
        Task<PagedResultDto<ResourceDto>> GetResourcesMeetingRoom(GetResourcesInput input);
        Task<PagedResultDto<ResourceDto>> GetResourcesLibrary(GetResourcesInput input);

        Task<ListResultDto<UserDto>> GetResourceManagers();
    }
}
