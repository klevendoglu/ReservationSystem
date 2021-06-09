using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemManager : DomainService
    {
        private readonly IRepository<Reservation, Guid> _reservationRepository;

        public ReservationSystemManager(IRepository<Reservation, Guid> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> CreateAsync(
            string reserverNote        
            )
        {

            return new Reservation(
                GuidGenerator.Create(),
                Enum.Status.Pending,
                reserverNote
            );
        }
    }
}
