using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ReservationSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(ReservationSystemEntityFrameworkCoreModule)
        )]
    public class ReservationSystemEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ReservationSystemMigrationsDbContext>();
        }
    }
}
