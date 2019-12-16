using System.Windows.Controls;

using MahApps.Metro.Controls;

using WpfWebView.Contracts.Views;
using WpfWebView.ViewModels;

namespace WpfWebView.Views
{
    public partial class ShellWindow : MetroWindow, IShellWindow
    {
        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();
    }
}
