using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class CreateReservationItemInputDto
    {
        public Guid ReservationId { get; set; }

        public Guid ResourceId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int RequestedHours { get; set; }

    }
}
