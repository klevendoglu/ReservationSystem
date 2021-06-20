namespace ReservationSystem.Permissions
{
    public static class ReservationSystemPermissions
    {
        public const string GroupName = "ReservationSystem";
        //public const string GroupName = "BookStore";

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

        public static class Books
        {
            public const string Default = GroupName + ".Books";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Authors
        {
            public const string Default = GroupName + ".Authors";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

    }
}