using ReservationSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ReservationSystem.Permissions
{
    public class ReservationSystemPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var reservationSystemGroup = context.AddGroup(ReservationSystemPermissions.GroupName);

            //var resourcesPermission = reservationSystemGroup.AddPermission(ReservationSystemPermissions.Resources.Default, L("Permission:Resources"),);
            //resourcesPermission.AddChild(ReservationSystemPermissions.Resources.Create, L("Permission:Resources.Create"));
            //resourcesPermission.AddChild(ReservationSystemPermissions.Resources.Edit, L("Permission:Resources.Edit"));
            //resourcesPermission.AddChild(ReservationSystemPermissions.Resources.Delete, L("Permission:Resources.Delete"));

            //var reservationsPermission = reservationSystemGroup.AddPermission(ReservationSystemPermissions.Resources.Default, L("Permission:Reservations"));
            //reservationsPermission.AddChild(ReservationSystemPermissions.Reservations.Create, L("Permission:Reservations.Create"));
            //reservationsPermission.AddChild(ReservationSystemPermissions.Reservations.Edit, L("Permission:Reservations.Edit"));
            //reservationsPermission.AddChild(ReservationSystemPermissions.Reservations.Delete, L("Permission:Reservations.Delete"));

            var reservationSystemGroup = context.AddGroup(ReservationSystemPermissions.GroupName);
            reservationSystemGroup.AddPermission("Reservations.Default", L("Permission:Reservations.Default"));
            reservationSystemGroup.AddPermission("Reservations.Create", L("Permission:Reservations.Create"));
            reservationSystemGroup.AddPermission("Reservations.Edit", L("Permission:Reservations.Edit"));
            reservationSystemGroup.AddPermission("Reservations.Delete", L("Permission:Reservations.Delete"));

            reservationSystemGroup.AddPermission("Resources.Default", L("Permission:Resources.Default"));
            reservationSystemGroup.AddPermission("Resources.Create", L("Permission:Resources.Create"));
            reservationSystemGroup.AddPermission("Resources.Edit", L("Permission:Resources.Edit"));
            reservationSystemGroup.AddPermission("Resources.Delete", L("Permission:Resources.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ReservationSystemResource>(name);
        }
    }
}
