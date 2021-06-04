using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace ReservationSystem.Users
{
    public class UserDto : EntityDto<Guid>, IHasCreationTime
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public Guid? ProfilePictureId { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public List<UserRoleDto> Roles { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
