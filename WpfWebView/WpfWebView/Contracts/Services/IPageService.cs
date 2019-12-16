using System;
using System.Windows.Controls;

namespace WpfWebView.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
