using HtkTennis.Utilities;

using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Court
    {
        #region
        protected int pkCourtId;
        protected string courtName;
        #endregion

        public Court()
        {
            Reservations = new HashSet<Reservation>();
        }

        #region Properties
        /// <summary>
        /// Id of the <see cref="Court"/>
        /// </summary>
        public virtual int PkCourtId
        {
            get
            {
                return pkCourtId;
            }
            set
            {
                if(pkCourtId != value)
                {
                    // Using the validation class, check if the int is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        pkCourtId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(pkCourtId));
                    }
                }
            }
        }

        /// <summary>
        /// Name of the <see cref"Court"/>
        /// </summary>
        public virtual string CourtName
        {
            get
            {
                return courtName;
            }
            set
            {
                if(courtName != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        courtName = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(courtName));
                    }
                }
            }
        }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Reservation> Reservations { get; set; }
        #endregion
    }
}