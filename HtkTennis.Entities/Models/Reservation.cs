using HtkTennis.Utilities;

using System;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {
        #region Fields
       protected int pkReservationId;
       protected int fkCourtId;
       protected int fkFirstMemberId;
       protected int fkSecondMemberId;
       protected DateTime startTime;
       protected DateTime endTime;
        #endregion

        #region Properties
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
        /// Id of the first player <see cref="Member"/>
        /// </summary>
        public virtual int FkFirstMemberId
        {
            get
            {
                return fkFirstMemberId;
            }
            set
            {
                if(fkFirstMemberId != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkFirstMemberId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(PkReservationId));
                    }
                }
            }
        }

        /// <summary>
        /// Id of the second player <see cref="Member"/>
        /// </summary>
        public virtual int FkSecondMemberId
        {
            get
            {
                return fkSecondMemberId;
            }
            set
            {
                if(fkSecondMemberId != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkSecondMemberId = value;
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
                        startTime = value;
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
        public virtual Member FkFirstMemberNavigation { get; set; }
        public virtual Member FkSecondMemberNavigation { get; set; }
        #endregion
    }
}
