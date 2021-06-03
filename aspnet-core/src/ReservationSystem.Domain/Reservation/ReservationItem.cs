using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace ReservationSystem.Reservation
{
    public class ReservationItem : ValueObject
    {
        public Guid ReservationId { get; private set; }

        public Guid ResourceId { get; private set; }

        public DateTime StartTime { get; private set; }

        public int RequestedHours { get; private set; }

        public DateTime EndTime { get; private set; }

        public DateTime? ReturnTime { get; private set; }

        public int? OverDue { get; private set; }

        public Enum.Status Status { get; private set; }

        public ReservationItem(
            Guid reservationId,
            Guid resourceId,
            DateTime startTime,
            int requestedHours,
            DateTime endTime,
            DateTime? returnTime,
            int? overDue,
            Enum.Status status
            )
        {
            ReservationId = reservationId;
            ResourceId = resourceId;
            StartTime = startTime;
            RequestedHours = requestedHours;
            EndTime = endTime;
            ReturnTime = returnTime;
            OverDue = overDue;
            Status = status;
        }

        private ReservationItem()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ReservationId;
            yield return ResourceId;
            yield return StartTime;
            yield return RequestedHours;
            yield return EndTime;
            yield return ReturnTime;
            yield return OverDue;
            yield return Status;   
        }
    }
}
