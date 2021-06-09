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

        public async Task<ReservationDto> CreateReservationAsync(CreateReservationInputDto input)
        {
            var reservation = await _reservationSystemManager.CreateAsync(
                input.ReserverNotes
            );

            //TODO://Perform AddReservationItem in manager class.

            //var reservationItemsQueryable = await _reservationItemRepository.GetQueryableAsync();
            //var itemsInUse = AsyncExecuter.ToListAsync(
            //    reservationItemsQueryable
            //        .Where(
            //            new InActiveIssueSpecification()
            //                .And(new MilestoneSpecification(milestoneId))
            //                .ToExpression()
            //        )
            //);

            throw new NotImplementedException();
        }

        public Task<ReservationDto> CreateRecurringReservationAsync(CreateRecurringReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservationAsync(UpdateReservationInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task ProcessReservationAsync(ProcessReservationInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReservationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ReturnReservationAsync(ReturnReservationInputDto input)
        {
            throw new NotImplementedException();
        }

    }
}
