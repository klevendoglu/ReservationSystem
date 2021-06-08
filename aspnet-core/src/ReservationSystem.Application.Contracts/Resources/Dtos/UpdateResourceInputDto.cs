using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReservationSystem.Resources.Dtos
{
    public class UpdateResourceInputDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ResourceConsts.MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(ResourceConsts.MaxNameLength)]
        public string Location { get; set; }

        [MaxLength(ResourceConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        public string Image { get; set; }

        [MaxLength(ResourceConsts.MaxSerialLength)]
        public string Serial { get; set; }

        public int MaxReservationHours { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        public byte Category { get; set; }
    }
}
