using Microsoft.EntityFrameworkCore;
using ReservationSystem.Reservations;
using ReservationSystem.Resources;
using ReservationSystem.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace ReservationSystem.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See ReservationSystemMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class ReservationSystemDbContext : AbpDbContext<ReservationSystemDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ReservationItem> ReservationItems { get; set; }

        public DbSet<OverduePayment> OverduePayments { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside ReservationSystemDbContextModelCreatingExtensions.ConfigureReservationSystem
         */

        public ReservationSystemDbContext(DbContextOptions<ReservationSystemDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the ReservationSystemEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureReservationSystem method */

            builder.ConfigureReservationSystem();
        }
    }
}
