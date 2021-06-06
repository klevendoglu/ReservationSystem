using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class ReservationDto : FullAuditedEntityDto
    {
        public Guid Id { get; set; }

        public Enum.Status Status { get; set; }

        public string ReserverNotes { get; set; }

        public string ManagerNotes { get; set; }

        public UserDto CreatorUser { get; set; }

        public List<ReservationItemDto> ReservationItems { get; set; }

        public string StatusText => Status.ToString();

        public bool IsProcessed => Status == Enum.Status.Processed;

        public bool IsFinished => Status == Enum.Status.Finished;

        public bool IsPending => Status == Enum.Status.Pending;
    }
}
