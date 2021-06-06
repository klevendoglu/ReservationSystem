using ReservationSystem.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Test.Base.TestData
{
    public class TestDataBuilder
    {
        private readonly ReservationSystemDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(ReservationSystemDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            //new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            //new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            //new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
