using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Provides data for a log message event handler
    /// </summary>
    public class LogMessageEventArgs : EventArgs
    {
        public LogMessageEventArgs(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            Message = message;
        }

        public virtual string Message { get; protected set; }
    }
}
