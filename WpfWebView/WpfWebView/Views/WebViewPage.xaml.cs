using System.Windows.Controls;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

using WpfWebView.ViewModels;

namespace WpfWebView.Views
{
    public partial class WebViewPage : Page
    {
        private readonly WebViewViewModel _viewModel;

        public WebViewPage(WebViewViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            _viewModel.Initialize(webView, refreshButton);
        }

        private void OnNavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
            => _viewModel.OnNavigationCompleted(e);

        private void OnLostFocus(object sender, System.Windows.RoutedEventArgs e)
            => webView.MoveFocus(WebViewControlMoveFocusReason.Next);
    }
}
