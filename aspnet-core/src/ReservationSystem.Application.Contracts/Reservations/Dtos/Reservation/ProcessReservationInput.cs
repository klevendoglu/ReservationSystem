using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ProcessReservationInput
    {
        public Guid ReservationId { get; set; }

        public string ManagerNotes { get; set; }

        public List<ProcessReservationItemInputDto> ReservationItems { get; set; }
    }
}
