using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemAppService : ApplicationService, IReservationSystemAppService
    {
        private readonly ReservationSystemManager _reservationSystemManager;
        private readonly IRepository<Reservation, Guid> _reservationRepository;
        private readonly IRepository<ReservationItem, Guid> _reservationItemRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        private readonly IAsyncQueryableExecuter _asyncExecuter;

        public ReservationSystemAppService(
            ReservationSystemManager reservationSystemManager,
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<ReservationItem, Guid> reservationItemRepository,
            IRepository<AppUser, Guid> userRepository,
            IAsyncQueryableExecuter asyncExecuter
            )
        {
            _reservationSystemManager = reservationSystemManager;
            _reservationRepository = reservationRepository;
            _reservationItemRepository = reservationItemRepository;
            _userRepository = userRepository;

            _asyncExecuter = asyncExecuter;
        }

        public async Task<ReservationDto> CreateAsync(CreateReservationInputDto input)
        {
            var reservation = _reservationSystemManager.Create(
                input.ReserverNotes,
                input.RequestedItems.Count
            );

            await _reservationSystemManager.AddReservationItems(reservation, InitializeReservationItemList(reservation, input.RequestedItems));

            await _reservationRepository.InsertAsync(reservation);

            return ObjectMapper.Map<Reservation, ReservationDto>(reservation);
        }

        public async Task<PagedResultDto<ReservationDto>> GetListAsync(GetReservationsInput input)
        {
            //Set a default sorting, if not provided
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Reservation.Id);
            }

            var queryable = await _reservationRepository.GetQueryableAsync();

            var reservations = await _asyncExecuter.ToListAsync(
                queryable                    
                    .OrderBy(input.Sorting)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
            );

            var reservationDtos = ObjectMapper.Map<List<Reservation>, List<ReservationDto>>(reservations);
            var totalCount = await _reservationRepository.GetCountAsync();
            return new PagedResultDto<ReservationDto>(totalCount, reservationDtos);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        private List<ReservationItem> InitializeReservationItemList(Reservation reservation, List<CreateReservationItemInputDto> requestedItems)
        {
            var reservationItems = new List<ReservationItem>();
            for (int i = 0; i < requestedItems.Count; i++)
            {
                var requestedItem = requestedItems.ElementAt(i);
                var reservationItem = _reservationSystemManager.CreateReservationItem(
                    reservation.Id,
                    requestedItem.ResourceId,
                    requestedItem.StartTime,
                    requestedItem.RequestedHours
                    );
                reservationItems.Add(reservationItem);
            }
            return reservationItems;
        }
    }
}
