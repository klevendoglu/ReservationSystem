using ReservationSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ReservationSystem.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ReservationSystemEntityFrameworkCoreDbMigrationsModule),
        typeof(ReservationSystemApplicationContractsModule)
        )]
    public class ReservationSystemDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
