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
        Task<ResourceDto> UpdateAsync(Guid id, UpdateResourceInputDto input);
        Task<ResourceDto> GetAsync(Guid id);
        Task<PagedResultDto<ResourceDto>> GetListAsync(GetResourcesInput input);
        Task<ListResultDto<UserDto>> GetResourceManagers();
    }
}
