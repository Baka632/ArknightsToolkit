using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.ViewModels
{
    internal class FrontPageViewModel : NotificationObject
    {
        public DelegateCommand NavigateToOperatorsCommand { get; }
        public NavigationCommand NavigateToStoryPageCommand { get; } = new NavigationCommand(typeof(StoryPage), null);


        public FrontPageViewModel()
        {
            NavigateToOperatorsCommand = new DelegateCommand(async (obj) =>
            {
                if (OptionalPackageHelper.CheckIfOperatorPackageAvailable())
                {
                    NavigationHelper.Navigate(typeof(OperatorLists), null);
                }
                else
                {
                    NotifyInstallPackageDialog dialog = new NotifyInstallPackageDialog();
                    dialog.SetPackageName("Arknights Toolkit Operator Pack");
                    _ = await dialog.ShowAsync();
                }
            });
        }
    }
}
