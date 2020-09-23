using HtkTennis.Utilities;
using System;
using System.Collections.Generic;

namespace HtkTennis.Entities
{
    public partial class Ranking
    {
        #region Fields
        private int pkRankId;
        private int fkMemberId;
        private int points;
        #endregion

        #region Properties
        /// <summary>
        /// Id of the case <see cref="Ranking"/>
        /// </summary>
        public int PkRankId
        {
            get
            {
                return pkRankId;
            }
            set
            {
                if(pkRankId != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        pkRankId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(pkRankId));
                    }
                }
            }
        }

        /// <summary>
        /// Id of the <see cref="Member"/>
        /// </summary>
        public int FkMemberId
        {
            get
            {
                return fkMemberId;
            }
            set
            {
                if(fkMemberId != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        fkMemberId = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(fkMemberId));
                    }
                }
            }
        }
        /// <summary>
        /// Points of the <see cref="Ranking"/>
        /// </summary>
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if(points != value)
                {
                    (bool isValid, string errorMessage) = Validations.ValidateIsIntNegative(value);
                    if(isValid)
                    {
                        points = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(points));
                    }
                }
            }
        }
        #endregion

        #region Navigation Properties
        public virtual Member FkMember { get; set; }
        #endregion

    }
}