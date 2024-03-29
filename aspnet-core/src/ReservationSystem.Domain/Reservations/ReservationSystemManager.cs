﻿using Microsoft.Extensions.Localization;
using ReservationSystem.Localization;
using ReservationSystem.Reservations.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Linq;

namespace ReservationSystem.Reservations
{
    public class ReservationSystemManager : DomainService
    {
        private readonly IRepository<Reservation, Guid> _reservationRepository;
        private readonly IRepository<ReservationItem, Guid> _reservationItemRepository;

        private readonly IAsyncQueryableExecuter _asyncExecuter;
        private readonly IStringLocalizer<ReservationSystemResource> _stringLocalizer;

        public ReservationSystemManager(
            IRepository<Reservation, Guid> reservationRepository,
            IRepository<ReservationItem, Guid> reservationItemRepository,
            IAsyncQueryableExecuter asyncExecuter,
            IStringLocalizer<ReservationSystemResource> stringLocalizer
            )
        {
            _reservationRepository = reservationRepository;
            _reservationItemRepository = reservationItemRepository;
            _asyncExecuter = asyncExecuter;
            _stringLocalizer = stringLocalizer;
        }

        public Reservation Create(
            string reserverNote,
            int requestedItemCount
            )
        {
            if (requestedItemCount <= 0)
            {
                throw new BusinessException(ReservationSystemDomainErrorCodes.ReservationItemsShouldBeGreaterThanZero);
            }

            return new Reservation(
                GuidGenerator.Create(),
                Enum.Status.Pending,
                reserverNote
            );
        }

        public ReservationItem CreateReservationItem(
            Guid reservationId,
            Guid resourceId,
            DateTime startTime,
            int requestedHours
            )
        {

            return new ReservationItem(
                GuidGenerator.Create(),
                reservationId,
                resourceId,
                startTime,
                requestedHours,
                endTime: startTime.AddHours(requestedHours),
                Enum.Status.Pending
             );
        }

        public async Task AddReservationItems(Reservation reservation, List<ReservationItem> reservationItems)
        {
            for (int i = 0; i < reservationItems.Count; i++)
            {
                var reservationItem = reservationItems.ElementAt(i);

                CheckReservationItemAvailabilityHours(reservationItem);

                await CheckConflictingReservationItem(reservationItem);

                reservation.AddReservationItem(reservationItem);
            }
        }

        private void CheckReservationItemAvailabilityHours(ReservationItem reservationItem)
        {
            var startTime = reservationItem.StartTime;
            var endTime = startTime.AddHours(reservationItem.RequestedHours);
            var startDate = startTime.Date;
            var endDate = endTime.Date;
            if (startTime.Date.DayOfWeek == DayOfWeek.Saturday || startTime.Date.DayOfWeek == DayOfWeek.Sunday ||
                endTime.Date.DayOfWeek == DayOfWeek.Saturday || endTime.Date.DayOfWeek == DayOfWeek.Sunday ||
                (!Between(startTime, startDate.AddHours(9), startDate.AddHours(12)) && !Between(startTime, startDate.AddHours(14), startDate.AddHours(17))) ||
                (!Between(endTime, endDate.AddHours(9), endDate.AddHours(12)) && !Between(endTime, endDate.AddHours(14), endDate.AddHours(17))))
            {
                throw new BusinessException(_stringLocalizer["ReservationItemAvailabilityHours"], _stringLocalizer["ReservationItemAvailabilityHours"]);
            }
        }

        private async Task CheckConflictingReservationItem(ReservationItem item)
        {
            var reservationItemQuaryable = await _reservationItemRepository.GetQueryableAsync();
            var itemsInUse = await _asyncExecuter.ToListAsync(reservationItemQuaryable.Where(new ItemsInUseSpecification()));

            var conflictingItem = itemsInUse.FirstOrDefault(x => x.ResourceId == item.ResourceId &&
                        ((item.StartTime >= x.StartTime && item.StartTime < x.EndTime) ||
                        (item.EndTime > x.StartTime && item.EndTime <= x.EndTime) ||
                        (item.StartTime <= x.StartTime && item.EndTime >= x.EndTime)));

            if (conflictingItem != null)
            {
                throw new BusinessException(ReservationSystemDomainErrorCodes.ConflictingItemFound);
            }
        }

        private bool Between(DateTime date, DateTime start, DateTime end, bool inclusive = true)
        {
            return inclusive
                ? start <= date && date <= end
                : start < date && date < end;
        }
    }
}
