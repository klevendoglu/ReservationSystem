using JetBrains.Annotations;
using System;
using Volo.Abp.Domain.Entities;

namespace ReservationSystem.Reservations
{
    public class ReservationItem : Entity<Guid>
    {
        public Guid ReservationId { get; set; }

        public Guid ResourceId { get; set; }

        public DateTime StartTime { get; set; }

        public int RequestedHours { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public int? OverDue { get; set; }

        public Enum.Status Status { get; set; }

        internal ReservationItem(
            Guid id,
            Guid reservationId,
            Guid resourceId,
            DateTime startTime,
            int requestedHours,
            DateTime endTime,
            Enum.Status status,
            [CanBeNull] DateTime? returnTime = null,
            [CanBeNull] int? overDue = null
            ) : base(id)
        {
            ReservationId = reservationId;
            ResourceId = resourceId;
            StartTime = startTime;
            RequestedHours = requestedHours;
            EndTime = endTime;
            Status = status;
            ReturnTime = returnTime;
            OverDue = overDue;
        }

        private ReservationItem() { }

    }
}
