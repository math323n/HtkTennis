using HtkTennis.Utilities;

using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {
        #region Fields
        private int pkReservationId;
        private int fkCourtId;
        private int fkFirstMemberId;
        private int fkSecondMemberId;
        #endregion

        public int PkReservationId
        {
            get
            {
                return pkReservationId;
            }
            set
            {
                if(pkReservationId != value)
                {
                    // Using the validation class, check if the value does not go below 0
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

        public int FkCourtId
        {
            get
            {
                return fkCourtId;
            }
            set
            {
                if(fkCourtId != value)
                {
                    // Using the validation class, check if the value does not go below 0
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkCourtId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(FkCourtId));
                    }
                }
            }
        }

        public int FkFirstMemberId
        {
            get
            {
                return fkFirstMemberId;
            }
            set
            {
                if(fkFirstMemberId != value)
                {
                    // Using the validation class, check if the value does not go below 0
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkFirstMemberId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(FkFirstMemberId));
                    }
                }
            }
        }


        public int FkSecondMemberId
        {
            get
            {
                return fkSecondMemberId;
            }
            set
            {
                if(fkSecondMemberId != value)
                {
                    // Using the validation class, check if the value does not go below 0
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkSecondMemberId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(fkSecondMemberId));
                    }
                }
            }
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }
    }
}
