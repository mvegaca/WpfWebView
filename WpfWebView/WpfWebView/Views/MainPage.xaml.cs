using System.Windows.Controls;

using WpfWebView.ViewModels;

namespace WpfWebView.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
