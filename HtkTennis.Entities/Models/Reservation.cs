using HtkTennis.Utilities;
using System;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {
        #region Fields
        int pkReservationId;
        int fkCourtId;
        int fkFirstMember;
        int fkSecondMember;
        DateTime startTime;
        DateTime endTime;
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
        public virtual int FkFirstMember
        {
            get
            {
                return fkFirstMember;
            }
            set
            {
                if(fkFirstMember != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkFirstMember = value;
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
        public virtual int FkSecondMember
        {
            get
            {
                return fkSecondMember;
            }
            set
            {
                if(fkSecondMember != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkSecondMember = value;
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
        public DateTime StartTime
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
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if(endTime != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateAfter(value, startTime);
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