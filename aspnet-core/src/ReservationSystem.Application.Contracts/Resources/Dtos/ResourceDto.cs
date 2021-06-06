using ReservationSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReservationSystem.Resources.Dtos.Resource
{
    public class ResourceDto : FullAuditedEntityDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Serial { get; set; }

        public Guid ManagerId { get; set; }

        public UserDto Manager { get; set; }

        public UserDto CreatorUser { get; set; }

        public byte Category { get; set; }

        public Guid? ParentId { get; set; }

        public ResourceDto Parent { get; set; }

        public int MaxReservationHours { get; set; }

        public bool CanBeUsedForEvents { get; set; }
    }
}
