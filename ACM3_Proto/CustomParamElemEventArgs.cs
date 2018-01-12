using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FadingUtility.ViewModel;

namespace FadingUtility.Helpers
{
    // Summary:
    //     Provides data for the RemoveCustomParamElemEventHandler
    //     event.
    public class CustomParamElemEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the RemoveCustomParamElemEventArgs class
        /// </summary>
        /// <param name="errorMessage">error message</param>
        public CustomParamElemEventArgs(CustomParamElementViewModel element)
        {
            CustomParamElementVM = element;
        }

        public CustomParamElementViewModel CustomParamElementVM { get; protected set; }
    }
}
