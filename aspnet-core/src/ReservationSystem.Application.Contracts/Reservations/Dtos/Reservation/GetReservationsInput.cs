using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReservationSystem.Reservations.Dtos.Reservation
{
    public class GetReservationsInput : PagedAndSortedResultRequestDto
    {
        public Guid? ReservationId { get; set; }

        public Enum.Status? Status { get; set; }

        public Guid? ManagerId { get; set; }

        public Guid? CreatorUserId { get; set; }

        public Guid? ResourceId { get; set; }

        public bool IsOverDue { get; set; }

        public Enum.ResourceCategory? Category { get; set; }

        public string Filter { get; set; }

        public bool? HasUnreturnedResources { get; set; }

        public bool HasOverdueFee { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting = "ReservationId ASC";
            }
        }
    }
}
