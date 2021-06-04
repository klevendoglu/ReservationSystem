using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class UpdateReservationInputDto
    {
        public Guid Id { get; set; }

        public string ManagerNotes { get; set; }

        public Enum.Status Status { get; set; }
    }
}
