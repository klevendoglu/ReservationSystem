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
        private readonly IRepository<Reservation, Guid> _reservationRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public ReservationSystemAppService(
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }
    }
}
