using System.Windows.Controls;

namespace WpfWebView.Contracts.Views
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();
    }
}
