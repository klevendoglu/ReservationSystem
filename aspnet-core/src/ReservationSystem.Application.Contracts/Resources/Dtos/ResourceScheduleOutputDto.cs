using ReservationSystem.Reservations.Dtos.Reservation;
using ReservationSystem.Resources.Dtos.Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Resources.Dtos
{
    public class ResourceScheduleOutputDto
    {
        public ResourceDto Resource { get; set; }

        public List<ReservationItemDto> ReservationItems { get; set; }
    }
}
