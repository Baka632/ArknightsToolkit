using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ArknightsToolkit.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“内容对话框”项模板

namespace ArknightsToolkit.Views
{
    public sealed partial class NotifyInstallPackageDialog : ContentDialog
    {
        private NotifyInstallPackageDialogViewModel ViewModel { get; } = new NotifyInstallPackageDialogViewModel();

        public NotifyInstallPackageDialog()
        {
            this.InitializeComponent();
        }

        public void SetPackageName(string name)
        {
            ViewModel.PackageName = name;
        }
    }
}
