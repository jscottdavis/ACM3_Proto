using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Event handlers for showing or logging message.
    /// </summary>
    public class DebugEventHandler
    {
        #region User Message Handlers

        /// <summary>
        /// Raised when an error should be shown
        /// </summary>
        public event ShowErrorEventHandler ShowError;

        /// <summary>
        /// Raises this object's show error event.
        /// </summary>
        /// <param name="errorMessage">error message</param>
        /// <param name="caption">caption</param>
        /// <param name="supplementMsg">supplemental message</param>
        protected virtual void OnShowError(string errorMessage, string caption = null, string supplementMsg = null)
        {
            ShowErrorEventHandler handler = this.ShowError;
            if (handler != null)
            {
                var args = new ShowMessageEventArgs(errorMessage, caption, supplementMsg);
                handler(this, args);
            }
        }

        /// <summary>
        /// Handles a show error event raised by a sender.
        /// Bubbles up the event to the ShowErrorEventHandler.
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="e">show message event arguments</param>
        protected virtual void HandleShowError(object sender, ShowMessageEventArgs e)
        {
            ShowErrorEventHandler handler = this.ShowError;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raised when info should be shown
        /// </summary>
        public event ShowInfoEventHandler ShowInfo;

        /// <summary>
        /// Raises this object's show info event.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="caption">caption</param>
        /// <param name="supplementMsg">(optional)supplemental message</param>
        protected virtual void OnShowInfo(string message, string caption = null, string supplementMsg = null)
        {
            ShowInfoEventHandler handler = this.ShowInfo;
            if (handler != null)
            {
                var args = new ShowMessageEventArgs(message, caption, supplementMsg);
                handler(this, args);
            }
        }

        /// <summary>
        /// Handles a show info event raised by a sender.
        /// Bubbles up the event to the ShowInfoEventHandler.
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="e">show message event arguments</param>
        protected virtual void HandleShowInfo(object sender, ShowMessageEventArgs e)
        {
            ShowInfoEventHandler handler = this.ShowInfo;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // User Message Handlers

        #region Log Message Handlers

        /// <summary>
        /// Raised when an exception should be logged
        /// </summary>
        public event LogExceptionEventHandler LogException;

        /// <summary>
        /// Raises this object's log exception event.
        /// </summary>
        /// <param name="exc">exception</param>
        /// <param name="supplementMsg">supplemental message</param>
        protected virtual void OnLogException(Exception exc, string supplementMsg)
        {
            LogExceptionEventHandler handler = this.LogException;
            if (handler != null)
            {
                var args = new LogExceptionEventArgs(exc, supplementMsg);
                handler(this, args);
            }
        }

        /// <summary>
        /// Handles a Log exception event raised by a sender.
        /// Bubbles up the event to the LogExceptionEventHandler.
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="e">log exception event arguments</param>
        protected virtual void HandleLogException(object sender, LogExceptionEventArgs e)
        {
            LogExceptionEventHandler handler = this.LogException;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raised when a message should be logged
        /// </summary>
        public event LogMessageEventHandler LogMessage;

        /// <summary>
        /// Raises this object's log message event.
        /// </summary>
        /// <param name="message">message</param>
        protected virtual void OnLogMessage(string message)
        {
            LogMessageEventHandler handler = this.LogMessage;
            if (handler != null)
            {
                var args = new LogMessageEventArgs(message);
                handler(this, args);
            }
        }

        /// <summary>
        /// Handles a Log message event raised by a sender.
        /// Bubbles up the event to the LogMessageEventHandler.
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="e">log message event arguments</param>
        protected virtual void HandleLogMessage(object sender, LogMessageEventArgs e)
        {
            LogMessageEventHandler handler = this.LogMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion // Log Message Handlers
    }
}
