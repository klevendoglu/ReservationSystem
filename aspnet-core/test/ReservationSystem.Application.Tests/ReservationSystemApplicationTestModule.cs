using Volo.Abp.Modularity;

namespace ReservationSystem
{
    [DependsOn(
        typeof(ReservationSystemApplicationModule),
        typeof(ReservationSystemDomainTestModule)
        )]
    public class ReservationSystemApplicationTestModule : AbpModule
    {

    }
}