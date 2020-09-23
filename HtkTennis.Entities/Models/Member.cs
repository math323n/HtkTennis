using HtkTennis.Utilities;
using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Member
    {
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string email;

        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }

        public virtual int PkMemberId { get; set; }

        public virtual string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if(firstName != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        firstName = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(firstName));
                    }
                }
            }
        }
        public virtual string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if(lastName != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        lastName = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(lastName));
                    }
                }
            }
        }

        public virtual string Address
        {
            get
            {
                return address;
            }

            set
            {
                if(address != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        Address = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Address));
                    }
                }
            }
        }

        public virtual string Email
        {
            get
            {
                return email;
            }

            set
            {
                if(email != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        Email = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Email));
                    }
                }
            }
        }

        public virtual DateTime Birthdate { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
    }
}