using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace ReservationSystem.Reservations.Specifications
{
    public class ItemsInUseSpecification : Specification<ReservationItem>
    {
        public override Expression<Func<ReservationItem, bool>> ToExpression()
        {
            return x => x.Status != Enum.Status.Available;
        }
    }
}
