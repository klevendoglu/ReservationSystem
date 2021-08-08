using ReservationSystem.Reservations.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ReservationSystem.Reservations
{
    public interface IReservationSystemAppService : IApplicationService
    {
        Task<ReservationDto> CreateAsync(CreateReservationInputDto input);

        Task<PagedResultDto<ReservationDto>> GetListAsync(GetReservationsInput input);

        Task DeleteAsync(Guid id);
    }
}
