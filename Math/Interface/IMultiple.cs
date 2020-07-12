using System;
using System.Collections.Generic;
using System.Text;

namespace Math.Interface
{
    public interface IMultiple
    {
        /// <summary>
        /// Method to validation one number is multiple of 11 (simple)
        /// </summary>
        /// <param name="number">Number to Validate</param>
        /// <returns>True if number is multiple of 11</returns>
        bool ValidationMultiple11(string number);
    }
}
