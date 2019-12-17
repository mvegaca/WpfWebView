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

        private void OnRefreshButtonLostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // This is a workarround to move the focus programatically into the WebView using the TAB key
            // https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/wpf-winforms/webview-known-issues#user-interaction
            webView.MoveFocus(WebViewControlMoveFocusReason.Next);
        }
    }
}
