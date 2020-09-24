using HtkTennis.Utilities;

using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Member
    {
        #region Fields
        protected int pkMemberId;
        protected string firstName;
        protected string lastName;
        protected string address;
        protected string email;
        protected DateTime birthdate;
        protected int phone;
        #endregion

        #region Constructor
        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationFkFirstMemberNavigations = new HashSet<Reservation>();
            ReservationFkSecondMemberNavigations = new HashSet<Reservation>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Id of the <see cref="Member"/>
        /// </summary>
        public virtual int PkMemberId
        {
            get
            {
                return pkMemberId;
            }
            set
            {
                if(pkMemberId != value)
                {
                    // Using the validation class, check if the int is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        pkMemberId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(pkMemberId));
                    }
                }
            }
        }

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
        /// Email of the case <see cref="Member "/>
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
                    (bool isValid, string errorMessage) = Validations.ValidateDateNotNull(birthdate);
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

        /// <summary>
        /// Birthdate of the case <see cref="Member"/>
        /// </summary>
        public virtual int Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if(phone != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(phone);
                    if(isValid)
                    {
                        phone = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(phone));
                    }
                }
            }
        }

        #endregion

        #region Navigation Properties
        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationFkFirstMemberNavigations { get; set; }
        public virtual ICollection<Reservation> ReservationFkSecondMemberNavigations { get; set; }
        #endregion

    }
}