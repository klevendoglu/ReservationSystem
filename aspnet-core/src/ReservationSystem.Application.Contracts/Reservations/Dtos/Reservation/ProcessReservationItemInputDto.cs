using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ProcessReservationItemInputDto
    {
        public Guid Id { get; set; }

        public Enum.Status Status { get; set; }
    }
}
