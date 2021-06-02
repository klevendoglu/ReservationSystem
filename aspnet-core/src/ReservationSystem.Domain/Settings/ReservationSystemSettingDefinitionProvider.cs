using Volo.Abp.Settings;

namespace ReservationSystem.Settings
{
    public class ReservationSystemSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ReservationSystemSettings.MySetting1));
        }
    }
}
