using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ReturnReservationItemInputDto
    {
        public Guid Id { get; set; }

        public DateTime? ReturnTime { get; set; }
    }
}
