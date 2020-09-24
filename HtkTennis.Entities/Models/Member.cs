using HtkTennis.Utilities;

using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Member
    {
        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationFkFirstMember = new HashSet<Reservation>();
            ReservationFkSecondMember = new HashSet<Reservation>();
        }

        public int PkMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationFkSecondMember { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}