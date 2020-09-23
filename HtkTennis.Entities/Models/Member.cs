using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Member
    {
        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }

        public int PkMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
    }
}
