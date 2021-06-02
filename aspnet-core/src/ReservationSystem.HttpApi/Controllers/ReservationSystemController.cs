using ReservationSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ReservationSystem.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ReservationSystemController : AbpController
    {
        protected ReservationSystemController()
        {
            LocalizationResource = typeof(ReservationSystemResource);
        }
    }
}