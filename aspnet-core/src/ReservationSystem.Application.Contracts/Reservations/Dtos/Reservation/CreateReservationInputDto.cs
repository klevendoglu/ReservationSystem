using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class CreateReservationInputDto
    {
        public string ReserverNotes { get; set; }

        public List<CreateReservationItemInputDto> RequestedItems { get; set; }

        public bool IsReservationApprovalRequired { get; set; }
    }
}
