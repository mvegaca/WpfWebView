using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using Microsoft.Xaml.Behaviors;

namespace WpfWebView.Behaviors
{
    public class WebViewAcceleratorKeysBehavior : Behavior<WebView>
    {
        private ModifierKeys _modifierKey = ModifierKeys.None;

        public InputBindingCollection WebViewInputBindings
        {
            get { return (InputBindingCollection)GetValue(WebViewInputBindingsProperty); }
            set { SetValue(WebViewInputBindingsProperty, value); }
        }

        public static readonly DependencyProperty WebViewInputBindingsProperty = DependencyProperty.Register("WebViewInputBindings", typeof(InputBindingCollection), typeof(WebViewAcceleratorKeysBehavior), new PropertyMetadata(new InputBindingCollection()));

        public WebViewAcceleratorKeysBehavior()
        {
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.AcceleratorKeyPressed += OnAcceleratorKeyPressed;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.AcceleratorKeyPressed -= OnAcceleratorKeyPressed;
        }

        private void OnAcceleratorKeyPressed(object sender, WebViewControlAcceleratorKeyPressedEventArgs e)
        {
            if (e.EventType != CoreAcceleratorKeyEventType.KeyDown
                && e.EventType != CoreAcceleratorKeyEventType.SystemKeyDown
                && WebViewInputBindings.Count == 0)
            {
                return;
            }

            e.Handled = true;
            if (e.VirtualKey.IsModifierKey())
            {
                _modifierKey = e.VirtualKey.GetModifierKey();
                return;
            }

            if (Enum.TryParse(e.VirtualKey.ToString(), out Key key))
            {
                foreach (KeyBinding keyBinding in WebViewInputBindings)
                {
                    if (_modifierKey == keyBinding.Modifiers && key == keyBinding.Key)
                    {
                        keyBinding.Command.Execute(keyBinding.CommandParameter);
                    }
                }
            }

            _modifierKey = ModifierKeys.None;
        }
    }
}
