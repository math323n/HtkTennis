using HtkTennis.Utilities;
using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Member
    {
        #region Fields
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string email;
        protected DateTime birthdate;
        #endregion

        #region Constructor
        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Id of the case <see cref="Member"/>
        /// </summary>
        public virtual int PkMemberId { get; set; }

        /// <summary>
        /// First name of the case <see cref="Member"/>
        /// </summary>
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

        /// <summary>
        /// Last name of the case <see cref="Member"/>
        /// </summary>
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


        /// <summary>
        /// Address of the case <see cref="Member"/>
        /// </summary>
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

        /// <summary>
        /// Email of the case <see cref="Member"/>
        /// </summary>
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
        /// <summary>
        /// Birthdate of the case <see cref="Member"/>
        /// </summary>
        public virtual DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                if(birthdate != value)
                {
                    // Using the validation class, check if the DateTime is not null
                    (bool isValid, string errorMessage) = Validations.ValidateDateNotNull(value);
                    if(isValid)
                    {
                        birthdate = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(birthdate));
                    }
                }
            }
        }
        #endregion

        #region Navigation Properties

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
        #endregion
    }
}