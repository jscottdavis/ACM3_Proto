using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace FadingUtility.Helpers
{
    public class TextBoxValidationErrorHandler
    {
        public static void TextBoxValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show((string)e.Error.ErrorContent, "Invalid input");
                TextBox txtBox = ((RoutedEventArgs)e).OriginalSource as TextBox;
                if (txtBox != null)
                {
                    BindingOperations.GetBindingExpressionBase((DependencyObject)txtBox, TextBox.TextProperty).UpdateTarget(); // update text property
                }
            }
            else if (e.Action == ValidationErrorEventAction.Removed)
            {
                Validation.SetErrorTemplate((DependencyObject)((RoutedEventArgs)e).OriginalSource, null); // clear the red border
            }
        }
    }
}
