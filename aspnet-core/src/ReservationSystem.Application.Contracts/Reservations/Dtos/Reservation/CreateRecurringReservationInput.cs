using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class CreateRecurringReservationInput
    {
        [Required]
        public Guid ResourceId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public int StartHour { get; set; }

        [Required]
        public int EndHour { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
