using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Members
    {
        public Members()
        {
            Rankings = new HashSet<Rankings>();
            ReservationsFkFirstMember = new HashSet<Reservations>();
            ReservationsFkSecondMember = new HashSet<Reservations>();
        }

        public int PkMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Rankings> Rankings { get; set; }
        public virtual ICollection<Reservations> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservations> ReservationsFkSecondMember { get; set; }
    }
}
