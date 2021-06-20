namespace ReservationSystem.Permissions
{
    public static class ReservationSystemPermissions
    {
        public const string GroupName = "ReservationSystem";

        public static class Resources
        {
            public const string Default = GroupName + ".Resources";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Reservations
        {
            public const string Default = GroupName + ".Reservations";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

    }
}