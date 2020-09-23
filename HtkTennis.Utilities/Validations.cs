using System;

namespace HtkTennis.Utilities
{/// <summary>
 /// Class containing static validation methods for encapsulation
 /// </summary>
    public static class Validations
    {
        #region String Validation Methods
        /// <summary>
        /// Checks if a string is null
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsStringNull(string input)
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

        #region Number Validation Methods
        /// <summary>
        /// Checks if a int is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsIntNegative(int number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a double is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsDoubleNegative(double number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a float is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsFloatNegative(float number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Checks if a decimal is negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateIsDecimalNegative(decimal number)
        {
            if(number < 0)
            {
                return (false, "The number cannot be lower than 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }
        #endregion

        #region Date Validation Methods
        /// <summary>
        /// Checks if a date is before another
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        public static (bool, string) ValidateIsDateBefore(DateTime firstDate, DateTime secondDate)
        {
            // Null check
            if(firstDate == null || secondDate == null)
            {
                return (false, "A date cannot be null");
            }

            // Convert dates to ints
            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            // Check if first is higher than second
            if(first > second)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "The second date was before the first date");
            }
        }

        /// <summary>
        /// Checks if a date is before another
        /// </summary>
        /// <param name="input"></param>
        /// <returns>(<see cref="bool"/>, <see cref="string"/>)</returns>
        public static (bool, string) ValidateIsDateAfter(DateTime firstDate, DateTime secondDate)
        {
            // Null check
            if(firstDate == null || secondDate == null)
            {
                return (false, "A date cannot be null");
            }

            // Convert dates to ints
            int first = Convert.ToInt32(firstDate.ToString("yyyyMMdd"));
            int second = Convert.ToInt32(secondDate.ToString("yyyyMMdd"));

            // Check if first is lower than second
            if(first < second)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "The second date was before the first date");
            }
        }
        #endregion
    }
}