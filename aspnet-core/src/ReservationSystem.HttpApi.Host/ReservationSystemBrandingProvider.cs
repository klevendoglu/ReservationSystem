using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ReservationSystem
{
    [Dependency(ReplaceServices = true)]
    public class ReservationSystemBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ReservationSystem";
    }
}
