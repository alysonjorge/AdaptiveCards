﻿using System;
using System.Windows;
#if WPF
using System.Windows.Controls;
using xaml = System.Windows.Controls;
#elif XAMARIN
using Xamarin.Forms;
using Button = AdaptiveCards.Rendering.ContentButton;
#endif

namespace AdaptiveCards.Rendering
{

    public partial class XamlRenderer 
        : AdaptiveRenderer<FrameworkElement, RenderContext>
    {

        protected Button CreateActionButton(ActionBase action, RenderContext renderContext)
        {
#if WPF
            var uiButton = new Button();
            xaml.TextBlock uiTitle = new xaml.TextBlock() { Text = action.Title };
            uiTitle.Style = this.GetStyle($"Adaptive.Action.Title");
            uiButton.Content = uiTitle;
            string name = this.GetType().Name.Replace("Action", String.Empty);
            uiButton.Style = this.GetStyle($"Adaptive.Action.{name}");
            return uiButton;

#elif XAMARIN
            var uiButton = new Button();
            // TODO: button styling
            uiButton.Text = action.Title;
            string name = this.GetType().Name.Replace("Action", String.Empty);
            uiButton.Style = this.GetStyle($"Adaptive.Action.{name}");
            return uiButton;
#endif
        }
    }
}