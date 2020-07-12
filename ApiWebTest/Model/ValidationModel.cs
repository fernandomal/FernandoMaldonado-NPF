using System.Runtime.InteropServices.ComTypes;

namespace ApiWebTest.Model
{
    /// <summary>
    /// Model Class to Validations
    /// </summary>
    public class ValidationModel
    {
        public ValidationModel(string number, bool isMultiple)
        {
            this.Number = number;
            this.IsMultiple = isMultiple;
        }

        /// <summary>
        /// Number to validate.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Result of Validation.
        /// </summary>
        public bool IsMultiple { get; private set; }
    }
}
