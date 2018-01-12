using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Provides data for a log exception event handler
    /// </summary>
    public class LogExceptionEventArgs
    {
        public LogExceptionEventArgs(Exception exception, string supplementMsg)
        {
            if (exception == null)
                throw new ArgumentNullException("exception");
            if (supplementMsg == null)
                throw new ArgumentNullException("supplementMsg");
            Except = exception;
            SupplementMessage = supplementMsg;
        }

        public virtual Exception Except { get; protected set; }
        public virtual string SupplementMessage { get; protected set; }
    }
}
