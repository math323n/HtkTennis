using HtkTennis.Utilities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace HtkTennis.Tests
{
    [TestClass]
    public class ValidationTests
    {
        #region String Validation Methods

        [TestMethod]
        public (bool, string) MyTestMethod(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return (false, "The value cannot be null, or empty");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        #endregion


        #region Date Validation Methods
        /// <summary>
        /// Checks if the reservation start date is before the end date
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        [TestMethod]
        public void ValidateReservationDatesTest()
        {
            DateTime firstDate = new DateTime(2010 - 01 - 01);
            DateTime secondDate = new DateTime(2010 - 01 - 02);

            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            Assert.IsTrue(first > second);
        }

        /// <summary>
        /// Tests that the implementation of <see cref="Validations.ValidateIsDateBefore(DateTime, DateTime)"/> returns true
        /// </summary>
        [TestMethod]
        public virtual void IsDateBeforeReturnsTrue()
        {
            // Arrange
            DateTime before;
            DateTime after;

            // Act
            before = new DateTime(2019, 12, 24);
            after = DateTime.Now;
            (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(before, after);

            // Assert
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// Tests that the implementation of <see cref="Validations.ValidateIsDateBefore(DateTime, DateTime)"/> returns false
        /// </summary>
        [TestMethod]
        public virtual void IsDateBeforeReturnsFalse()
        {
            // Arrange
            DateTime before;
            DateTime after;

            // Act
            before = new DateTime(2030, 12, 24);
            after = new DateTime(2020, 12, 24);
            (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(before, after);

            // Assert
            Assert.IsTrue(!isValid);
        }
        #endregion

    }
}