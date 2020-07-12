using Common;
using Math.Interface;
using System;

namespace Math
{
    public class Multiple : IMultiple
    {
        /// <summary>
        /// Method to validation one number is multiple of 11
        /// </summary>
        /// <param name="number">Number to Validate</param>
        /// <returns>True if number is multiple of 11</returns>
        public bool ValidationMultiple11(string number)
        {
            try
            {
                int n;
                if (int.TryParse(number, out n))
                {
                    if (n > 0)
                        return (n % 11) == 0;
                    else
                        new Exception(Message.DataInvalidParse);
                }
                else
                {
                    return ValidationMultiple11LongNumber(number);
                }
            }
            catch
            {
                new Exception(Message.DataInvalidParse);
            }

            return false;
        }

        /// <summary>
        /// Method to validation one longer number is multiple of 11
        /// </summary>
        /// <param name="number">Number to Validate</param>
        /// <returns>True if number is multiple of 11</returns>
        private bool ValidationMultiple11LongNumber(string number)
        {
            int length = number.Length;
            int evenValue = 0;
            int oddValue = 0;

            for (int i = 0; i < length; i++)
            {
                int value = int.Parse(number.Substring(i, 1));

                if ((i + 1) % 2 == 0)
                {
                    evenValue += value;
                }
                else
                {
                    oddValue += value;
                }
            }

            if ((evenValue % 11) == (oddValue % 11))
            {
                return true;
            }

            return false;
        }
    }
}
