using JetBrains.Annotations;
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

        internal Resource(
            Guid id,
            [NotNull] string name,
            Guid managerId,
            byte category,
            int maxReservationHours,
            Guid? parentId = null,
            [CanBeNull] string location = null,
            [CanBeNull] string serial = null,
            [CanBeNull] string image = null,
            [CanBeNull] string description = null
            ) : base(id)
        {
            SetName(name);
            Location = location;
            Serial = serial;
            SetManager(managerId);
            Category = category;
            MaxReservationHours = maxReservationHours;
            ParentId = parentId;
            Image = image;
            Description = description;
        }

        private Resource() { }

        internal void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: ResourceConsts.MaxNameLength
            );
        }

        internal Resource ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
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
