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
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ReservationSystemAppService(
            ReservationSystemManager reservationSystemManager,
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _reservationSystemManager = reservationSystemManager;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }

        public Task<ReservationDto> CreateReservation(CreateReservationInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> CreateRecurringReservation(CreateRecurringReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservation(UpdateReservationInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task ProcessReservation(ProcessReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReservation(Guid id)
        {
            throw new NotImplementedException();
        } 

        public Task ReturnReservation(ReturnReservationInputDto input)
        {
            throw new NotImplementedException();
        }
        
    }
}
