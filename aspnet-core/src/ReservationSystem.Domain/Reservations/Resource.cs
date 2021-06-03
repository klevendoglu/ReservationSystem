using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReservationSystem.Reservations
{
    public class Resource : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public string Location { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public string Serial { get; private set; }

        public Guid ManagerId { get; private set; }

        public byte Category { get; private set; }

        public Guid? ParentId { get; private set; }

        public int MaxReservationHours { get; private set; }

        public bool CanBeUsedForEvents { get; private set; }

        internal Resource(
            Guid id,
            string name,
            string location,
            string description,
            string image,
            string serial,
            Guid managerId,
            byte category,
            Guid? parentId,
            int maxReservationHours,
            bool canBeUsedForEvents
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
            CanBeUsedForEvents = canBeUsedForEvents;
        }

        private Resource()
        {

        }
    }
}
