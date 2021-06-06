using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReservationSystem.Resources
{
    public class Resource : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Serial { get; set; }

        public Guid ManagerId { get; private set; }

        public byte Category { get; set; }

        public Guid? ParentId { get; private set; }

        public int MaxReservationHours { get; set; }

        public Resource(
            Guid id,
            string name,
            string location,
            string description,
            string image,
            string serial,
            Guid managerId,
            byte category,
            Guid? parentId,
            int maxReservationHours
            ) : base(id)
        {
            Name = name;
            Location = location;
            Description = description;
            Image = image;
            Serial = serial;
            ManagerId = managerId;
            Category = category;
            ParentId = parentId;
            MaxReservationHours = maxReservationHours;
        }

        private Resource() { }

        internal void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        internal void SetParent(Guid id)
        {
            ParentId = id;
        }

        internal void SetManager(Guid id)
        {
            ManagerId = id;
        }
    }
}
