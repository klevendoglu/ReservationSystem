using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ReservationItemDto
    {
        public int ReservationId { get; set; }

        public int ResourceId { get; set; }

        public DateTime StartTime { get; set; }

        public int RequestedHours { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public int? OverDue { get; set; }

        public Enum.Status Status { get; set; }

        public string StatusText => Status.ToString();

        public bool IsOverDue => OverDue < 0;

        public bool IsFinished => Status == Enum.Status.Finished;

        public decimal OverDueFee => ReturnTime.HasValue && ReturnTime.Value > EndTime ? (decimal)((ReturnTime - EndTime).Value.TotalMinutes / 60.0 * (double)5M) : 0M;
    }
}
