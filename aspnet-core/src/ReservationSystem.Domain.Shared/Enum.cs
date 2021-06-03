using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem
{
    public class Enum
    {
        public enum Status
        {
            Pending, //0
            Approved,
            Rejected,
            Ready,
            Open,
            Assigned, //5
            Closed,
            InProcess,
            Processed,
            Finished,
            Requested, //10
            InUse,
            Available, //12
            Booked,
            Dropped,
            Withdrawn //15
        }
    }
}
