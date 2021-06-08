using ReservationSystem.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ReservationSystem
{
    public class ReservationSystemDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Reservation, Guid> _reservationRepository;
        private readonly IRepository<ReservationItem, Guid> _reservationItemRepository;
        private readonly ReservationSystemManager _reservationSystemManager;

        public ReservationSystemDataSeederContributor(
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<ReservationItem, Guid> reservationItemRepository,
            ReservationSystemManager reservationSystemManager)
        {
            _reservationRepository = reservationRepository;
            _reservationItemRepository = reservationItemRepository;
            _reservationSystemManager = reservationSystemManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _reservationRepository.GetCountAsync() > 0)
            {
                return;
            }

            //var reservation1 = await _reservationRepository.InsertAsync()
        }
    }
}
