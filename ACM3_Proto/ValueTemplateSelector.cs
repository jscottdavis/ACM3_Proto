using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using FadingUtility.ViewModel;

namespace FadingUtility.Helpers
{
    public class ValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringCellTemplate { get; set; }
        public DataTemplate DoubleCellTemplate { get; set; }
        public DataTemplate BoolCellTemplate { get; set; }
        public DataTemplate ListboxCellTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is CustomParamElementViewModel)
            {
                CustomParamElementViewModel viewModel = item as CustomParamElementViewModel;
                if (viewModel.Value is String)
                {
                    return StringCellTemplate;
                }
                else if (viewModel.Value is double)
                {
                    return DoubleCellTemplate;
                }
                else if (viewModel.Value is Boolean)
                {
                    return BoolCellTemplate;
                }
                else if (viewModel.Value is List<string>)
                {
                    return ListboxCellTemplate;
                }
            }
            return null;
        }
    }
}
