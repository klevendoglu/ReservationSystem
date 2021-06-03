using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ReservationSystem.Reservations
{
    public class Reservation : FullAuditedAggregateRoot<Guid>
    {
        public Enum.Status Status { get; private set; }

        public string ReserverNote { get; private set; }

        public string ManagerNote { get; private set; }

        public ICollection<ReservationItem> ReservationItems { get; set; }

        public ICollection<OverduePayment> OverduePayments { get; set; }

        internal Reservation(
            Guid id,
            Enum.Status status,
            string reserverNote = null,
            string managerNote = null
            ) : base(id)
        {
            ReserverNote = reserverNote; //Allow empty/null
            ManagerNote = managerNote;
            Status = status;

            ReservationItems = new Collection<ReservationItem>();
            OverduePayments = new Collection<OverduePayment>();
        }

        private Reservation() { /* Empty constructor is for ORMs */ }
    }
}
