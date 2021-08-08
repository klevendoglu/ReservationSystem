namespace ReservationSystem
{
    public static class ReservationSystemDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */
        public const string ReservationItemAvailabilityHours = "Reservation:ReservationItemAvailabilityHours";
        public const string ConflictingItemFound = "Reservation:ConflictingItemFound";
        public const string ReservationItemsShouldBeGreaterThanZero = "Reservation:ReservationItemsShouldBeGreaterThanZero";
    }
}
