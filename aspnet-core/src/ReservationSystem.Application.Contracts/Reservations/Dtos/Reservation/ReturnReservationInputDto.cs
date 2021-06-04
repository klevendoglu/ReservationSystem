using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ReturnReservationInputDto
    {
        public int ReservationId { get; set; }

        public string ManagerNotes { get; set; }

        public List<ReturnReservationItemInputDto> ReturnedItems { get; set; }
    }
}
