using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemAppService : ApplicationService, IReservationSystemAppService
    {
        private readonly ReservationSystemManager _reservationSystemManager;
        private readonly IRepository<Reservation, Guid> _reservationRepository;
        private readonly IRepository<ReservationItem, Guid> _reservationItemRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ReservationSystemAppService(
            ReservationSystemManager reservationSystemManager,
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<ReservationItem, Guid> reservationItemRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _reservationSystemManager = reservationSystemManager;
            _reservationRepository = reservationRepository;
            _reservationItemRepository = reservationItemRepository;
            _userRepository = userRepository;
        }

        public async Task<ReservationDto> CreateAsync(CreateReservationInputDto input)
        {
            var reservation = _reservationSystemManager.Create(
                input.ReserverNotes,
                input.RequestedItems.Count
            );

            var reservationItems = new List<ReservationItem>();
            for (int i = 0; i < input.RequestedItems.Count; i++)
            {
                var requestedItem = input.RequestedItems.ElementAt(i);
                var reservationItem = _reservationSystemManager.CreateReservationItem(
                    reservation.Id,
                    requestedItem.ResourceId,
                    requestedItem.StartTime,
                    requestedItem.EndTime,
                    requestedItem.RequestedHours
                    );
                reservationItems.Add(reservationItem);
            }

            await _reservationSystemManager.AddReservationItems(reservation, reservationItems);

            await _reservationRepository.InsertAsync(reservation);

            return ObjectMapper.Map<Reservation, ReservationDto>(reservation);
        }

        public Task<ReservationDto> CreateRecurringReservationAsync(CreateRecurringReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateReservationInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task ProcessReservationAsync(ProcessReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task ReturnReservationAsync(ReturnReservationInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
