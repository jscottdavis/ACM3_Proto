using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FadingUtility.Helpers
{
    // Summary:
    //     Provides data for the FadingUtility.Helpers.ShowErrorEventHandler or ShowInfoEventHandler
    //     event.
    public class ShowMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the FadingUtility.Helpers.ShowMessageEventArgs class
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="caption">caption to be displayed on a dialog title bar, if desired</param>
        /// <param name="supplementMessage">supplementary message(e.g. stack trace for an exception)</param>
        public ShowMessageEventArgs(string message, string caption, string supplementMessage)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            Message = message;
            Caption = caption == null ? String.Empty : caption;
            SupplementMessage = supplementMessage == null ? String.Empty : supplementMessage;
        }

        /// <summary>
        /// Initializes a new instance of the FadingUtility.Helpers.ShowErrorEventArgs class
        /// </summary>
        /// <param name="errorMessage">error message</param>
        public ShowMessageEventArgs(string message)
            : this(message, null, null)
        {
        }

        public virtual string Message { get; protected set; }
        public virtual string Caption { get; protected set; }
        public virtual string SupplementMessage { get; protected set; }
    }
}
