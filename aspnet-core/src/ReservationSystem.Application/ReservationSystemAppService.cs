using System;
using System.Collections.Generic;
using System.Text;
using ReservationSystem.Localization;
using Volo.Abp.Application.Services;

namespace ReservationSystem
{
    /* Inherit your application services from this class.
     */
    public abstract class ReservationSystemAppService : ApplicationService
    {
        protected ReservationSystemAppService()
        {
            LocalizationResource = typeof(ReservationSystemResource);
        }
    }
}
