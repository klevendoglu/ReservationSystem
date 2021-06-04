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
        //Task<List<ReservationItemWithReservationAndResourceListDto>> CreateReservation(CreateReservationInputDto input);

        //Task<List<ReservationItemWithReservationAndResourceListDto>> CreateRecurringReservation(CreateRecurringReservationInput input);

        Task UpdateReservation(UpdateReservationInputDto input);

        Task ProcessReservation(ProcessReservationInput input);

        Task ReturnReservation(ReturnReservationInputDto input);

        Task DeleteReservation(Guid id);
    }
}
