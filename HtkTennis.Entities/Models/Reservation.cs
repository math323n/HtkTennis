using HtkTennis.Utilities;
using System;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {
        #region Fields
        protected int pkReservationId;
        protected int fkCourtId;
        protected DateTime startTime;
        protected DateTime endTime;
        #endregion

        #region Properties
        public virtual int FkFirstMemberId { get; set; }
        public virtual int FkSecondMemberId { get; set; }


        /// <summary>
        /// Id of the <see cref="Reservation"/>
        /// </summary>
        public virtual int PkReservationId
        {
            get
            {
                return pkReservationId;
            }
            set
            {
                if(pkReservationId != value)
                {
                    // Using the validation class, check if the int is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        pkReservationId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(PkReservationId));
                    }
                }
            }
        }

        /// <summary>
        /// Id of the reservated <see cref="Court"/>
        /// </summary>
        public virtual int FkCourtId
        {
            get
            {
                return fkCourtId;
            }
            set
            {
                if(fkCourtId != value)
                {
                    // Using the validation class, check if the int is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkCourtId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(PkReservationId));
                    }
                }
            }
        }


        /// <summary>
        /// The starting time of the <see cref="Reservation"/>
        /// </summary>
        public virtual DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                if(startTime != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(value, endTime);
                    if(isValid)
                    {
                        StartTime = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(StartTime));
                    }
                }
            }
        }

        /// <summary>
        /// The time of which the <see cref="Reservation"/> ends
        /// </summary>
        public virtual DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if(endTime != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(startTime, value);
                    if(isValid)
                    {
                        endTime = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(EndTime));
                    }
                }
            }
        }
        #endregion

        #region Navigation Properties
        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }

        #endregion
    }
}