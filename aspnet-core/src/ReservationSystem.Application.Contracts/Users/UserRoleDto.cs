using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ReservationSystem.Users
{
    public class UserRoleDto : EntityDto<Guid>
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
