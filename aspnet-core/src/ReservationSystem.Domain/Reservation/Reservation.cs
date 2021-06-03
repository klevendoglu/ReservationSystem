using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReservationSystem.Reservation
{
    public class Reservation : FullAuditedAggregateRoot<Guid>
    {
        public Enum.Status Status { get; set; }

        public string ReserverNotes { get; set; }

        public string ManagerNotes { get; set; }

        public ICollection<ReservationItem> ReservationItems { get; set; }

        internal Reservation(
            Guid id,
            Enum.Status status,
            string reserverNotes = null,
            string managerNotes = null
            ) : base(id)
        {
            ReserverNotes = reserverNotes; //Allow empty/null
            ManagerNotes = managerNotes;
            Status = status;

            ReservationItems = new Collection<ReservationItem>();
        }

        private Reservation() { /* Empty constructor is for ORMs */ }
    }
}
