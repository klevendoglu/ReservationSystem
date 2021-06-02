using ReservationSystem.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ReservationSystem
{
    [DependsOn(
        typeof(ReservationSystemEntityFrameworkCoreTestModule)
        )]
    public class ReservationSystemDomainTestModule : AbpModule
    {

    }
}