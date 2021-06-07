using ReservationSystem.Reservations.Dtos.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ReservationSystem.Reservations
{
    public interface IReservationSystemAppService : IApplicationService
    {
        Task<ReservationDto> CreateReservationAsync(CreateReservationInputDto input);

        Task<ReservationDto> CreateRecurringReservationAsync(CreateRecurringReservationInput input);

        Task UpdateReservationAsync(UpdateReservationInputDto input);

        Task ProcessReservationAsync(ProcessReservationInput input);

        Task ReturnReservationAsync(ReturnReservationInputDto input);

        Task DeleteReservationAsync(Guid id);
    }
}
