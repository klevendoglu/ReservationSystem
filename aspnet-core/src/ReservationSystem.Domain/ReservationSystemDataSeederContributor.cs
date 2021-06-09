using ReservationSystem.Reservations;
using ReservationSystem.Resources;
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
        private readonly IRepository<Resource, Guid> _resourceRepository;

        private readonly ReservationSystemManager _reservationSystemManager;
        private readonly ResourceManager _resourceManager;

        public ReservationSystemDataSeederContributor(
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<ReservationItem, Guid> reservationItemRepository,
            IRepository<Resource, Guid> resourceRepository,
            ReservationSystemManager reservationSystemManager,
            ResourceManager resourceManager
            )
        {
            _reservationRepository = reservationRepository;
            _reservationItemRepository = reservationItemRepository;
            _resourceRepository = resourceRepository;

            _reservationSystemManager = reservationSystemManager;
            _resourceManager = resourceManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _reservationRepository.GetCountAsync() > 0)
            {
                return;
            }

            var reservation1 = await _reservationRepository.InsertAsync(
                await _reservationSystemManager.CreateAsync(
                    "Should reserve this camera"
                    )
            );

            //var user1 =

            var resource1 = await _resourceRepository.InsertAsync(
               await _resourceManager.CreateAsync(
                   "Camera",
                   Guid.NewGuid(),
                   new byte { },
                   5
                )
            );

            await _reservationItemRepository.InsertAsync(
                 new ReservationItem
                 {
                     ReservationId = reservation1.Id,
                     RequestedHours = 1,
                     ResourceId = resource1.Id,
                     StartTime = DateTime.Now,
                     Status = Enum.Status.Pending
                 },
                 autoSave: true
            );
        }
    }
}
