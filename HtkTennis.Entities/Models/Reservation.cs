using HtkTennis.Utilities;

using System;

namespace HtkTennis.Entities
{
    public partial class Reservation
    {

        protected DateTime startTime;
        protected DateTime endTime;

        public virtual int PkReservationId { get; set; }
        public virtual int FkCourtId { get; set; }
        public virtual int FkFirstMemberId { get; set; }
        public virtual int FkSecondMemberId { get; set; }

       

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
                    // Using the validation class, check if the start time of the reservation is before the end time
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(value, startTime);
                    if(isValid)
                    {
                        startTime = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(startTime));
                    }
                }
            }
        }

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
                    // Using the validation class, check if the start time of the reservation is before the end time
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(value, endTime);
                    if(isValid)
                    {
                        endTime = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(endTime));
                    }
                }
            }
        }

        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }
    }
}
