using ReservationSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ReservationSystem.Permissions
{
    public class ReservationSystemPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var reservationSystemGroup = context.AddGroup(ReservationSystemPermissions.GroupName, L("Permission:ReservationSystem"));

            var reservationsPermission = reservationSystemGroup.AddPermission(ReservationSystemPermissions.Resources.Default, L("Permission:Resources"));
            reservationsPermission.AddChild(ReservationSystemPermissions.Resources.Create, L("Permission:Resources.Create"));
            reservationsPermission.AddChild(ReservationSystemPermissions.Resources.Edit, L("Permission:Resources.Edit"));
            reservationsPermission.AddChild(ReservationSystemPermissions.Resources.Delete, L("Permission:Resources.Delete"));

            var resourcesPermission = reservationSystemGroup.AddPermission(ReservationSystemPermissions.Reservations.Default, L("Permission:Reservations"));
            resourcesPermission.AddChild(ReservationSystemPermissions.Reservations.Create, L("Permission:Reservations.Create"));
            resourcesPermission.AddChild(ReservationSystemPermissions.Reservations.Edit, L("Permission:Reservations.Edit"));
            resourcesPermission.AddChild(ReservationSystemPermissions.Reservations.Delete, L("Permission:Reservations.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ReservationSystemResource>(name);
        }
    }
}
