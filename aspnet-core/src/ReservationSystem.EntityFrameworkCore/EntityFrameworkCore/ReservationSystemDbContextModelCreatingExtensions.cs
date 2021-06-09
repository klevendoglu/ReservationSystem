using Microsoft.EntityFrameworkCore;
using ReservationSystem.Reservations;
using ReservationSystem.Resources;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ReservationSystem.EntityFrameworkCore
{
    public static class ReservationSystemDbContextModelCreatingExtensions
    {
        public static void ConfigureReservationSystem(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Resource>(b =>
            {
                b.ToTable("Resources", ReservationSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(250);
                b.Property(x => x.MaxReservationHours).IsRequired();
                b.Property(x => x.ManagerId).IsRequired();
                b.Property(x => x.Category).IsRequired();
            });

            builder.Entity<Reservation>(b =>
            {
                b.ToTable("Reservations", ReservationSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props

            });

            builder.Entity<ReservationItem>(b =>
            {
                b.ToTable("ReservationItems", ReservationSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //b.HasOne<Reservation>().WithMany().HasForeignKey(x => x.ReservationId).IsRequired();
            });

            builder.Entity<OverduePayment>(b =>
            {
                b.ToTable("OverduePayments", ReservationSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
            });

        }
    }
}