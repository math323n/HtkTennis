using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {
        public int PkReservationId { get; set; }
        public int FkCourtId { get; set; }
        public int FkFirstMemberId { get; set; }
        public int FkSecondMemberId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }
    }
}
