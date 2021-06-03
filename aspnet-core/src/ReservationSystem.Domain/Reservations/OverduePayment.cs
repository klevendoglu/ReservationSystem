using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ReservationSystem.Reservations
{
    public class OverduePayment : Entity<Guid>
    {
        public Guid ReservationId { get; private set; }

        public decimal PaymentAmount { get; private set; }

        public string Note { get; private set; }

        internal OverduePayment(
            Guid id,
            Guid reservationId,
            decimal paymentAmount,
            string note
            ) : base(id)
        {
            ReservationId = reservationId;
            PaymentAmount = paymentAmount;
            Note = note;
        }

        private OverduePayment()
        {

        }
    }
}
