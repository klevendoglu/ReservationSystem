using ReservationSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ReservationSystem.Permissions
{
    public class ReservationSystemPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ReservationSystemPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ReservationSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ReservationSystemResource>(name);
        }
    }
}
