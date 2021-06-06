using ReservationSystem.Resources.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReservationSystem.Resources.Dtos
{
    public class UpdateResourceInput
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ResourcesConsts.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(ResourcesConsts.MaxNameLength)]
        public string Location { get; set; }

        [MaxLength(ResourcesConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        public string Image { get; set; }

        [MaxLength(ResourcesConsts.MaxSerialLength)]
        public string Serial { get; set; }

        public int MaxReservationHours { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        public byte Category { get; set; }
    }
}
