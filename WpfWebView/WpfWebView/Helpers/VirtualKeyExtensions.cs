using System.Windows.Input;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    public static class VirtualKeyExtensions
    {
        public static bool IsModifierKey(this VirtualKey virtualKey)
            => virtualKey.GetModifierKey() != ModifierKeys.None;
        public static ModifierKeys GetModifierKey(this VirtualKey virtualKey)
        {
            switch (virtualKey)
            {
                case VirtualKey.Menu:
                case VirtualKey.LeftMenu:
                case VirtualKey.RightMenu:
                    return ModifierKeys.Alt;
                case VirtualKey.Control:
                case VirtualKey.LeftControl:
                case VirtualKey.RightControl:
                    return ModifierKeys.Control;
                case VirtualKey.Shift:
                case VirtualKey.LeftShift:
                case VirtualKey.RightShift:
                    return ModifierKeys.Shift;
                case VirtualKey.LeftWindows:
                case VirtualKey.RightWindows:
                    return ModifierKeys.Windows;
                default:
                    return ModifierKeys.None;
            }
        }
    }
}
