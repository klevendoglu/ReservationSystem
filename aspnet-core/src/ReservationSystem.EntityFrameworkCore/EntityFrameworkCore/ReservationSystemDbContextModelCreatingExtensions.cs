using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ReservationSystem.EntityFrameworkCore
{
    public static class ReservationSystemDbContextModelCreatingExtensions
    {
        public static void ConfigureReservationSystem(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ReservationSystemConsts.DbTablePrefix + "YourEntities", ReservationSystemConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}