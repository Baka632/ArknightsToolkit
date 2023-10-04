using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ArknightsToolkit.Services;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SettingsContentDialog : ContentDialog, INotifyPropertyChanged
    {
        private string _TempFolderSize;
        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsContentDialog()
        {
            this.InitializeComponent();
        }

        private async void MailTo(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:stevemc123456@outlook.com"));
        }

        private async void GoToGithub(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://github.com/Baka632/ArknightsToolkit"));
        }

        private async void RestartApp(object sender, RoutedEventArgs e)
        {
            AppRestartFailureReason result = await CoreApplication.RequestRestartAsync(String.Empty);
            if (result == AppRestartFailureReason.NotInForeground ||
                result == AppRestartFailureReason.RestartPending ||
                result == AppRestartFailureReason.Other)
            {
                System.Diagnostics.Debug.WriteLine($"RequestRestartAsync failed: {result}");
            }
        }

        public string TempFolderSize
        {
            get => _TempFolderSize;
            set
            {
                _TempFolderSize = value;
                OnPropertiesChanged();
            }
        }

        private async void ClearTempFolder(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            clearProgressRing.IsActive = true;
            await OperatorResourceService.RemoveImagesAsync();
            (sender as Button).IsEnabled = true;
            clearProgressRing.IsActive = false;
            var folder = OperatorResourceService.SaveFolder;
            uint count = await folder.CreateFileQuery().GetItemCountAsync();
            TempFolderSize = $"缓存的图片数:{count}";
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = OperatorResourceService.SaveFolder;
            uint count = await folder.CreateFileQuery().GetItemCountAsync();
            TempFolderSize = $"缓存的图片数:{count}";
        }

        /// <summary>
        /// 通知运行时属性已经发生更改
        /// </summary>
        /// <param name="propertyName">发生更改的属性名称,其填充是自动完成的</param>
        public void OnPropertiesChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void GenImages(object sender, RoutedEventArgs e)
        {
            OperatorResourceService.GenerateImagesAsync(true);
            var folder = OperatorResourceService.SaveFolder;
            uint count = await folder.CreateFileQuery().GetItemCountAsync();
            TempFolderSize = $"缓存的图片数:{count}";
        }
    }
}
