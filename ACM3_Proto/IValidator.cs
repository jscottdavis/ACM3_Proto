using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Performs validation
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Gets a boolean indicating this object is valid
        /// </summary>
        bool IsValid { get; }
    }
}
