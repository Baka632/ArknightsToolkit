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
    class FrontPageViewModel : NotificationObject
    {
        private BitmapImage tapeImage;

        public DelegateCommand NavigateToOperatorsCommand { get; set; } = new DelegateCommand();
        public DelegateCommand NavigateToStoryPageCommand { get; set; } = new DelegateCommand();
        public BitmapImage TapeImage
        {
            get => tapeImage;
            private set
            {
                tapeImage = value;
                OnPropertiesChanged();
            }
        }


        public FrontPageViewModel()
        {
            NavigateToOperatorsCommand.ExecuteAction = NavigateToOperatorsList;
            NavigateToStoryPageCommand.ExecuteAction = NavigateToStoryPage;
            SetTapeImage();

            async void SetTapeImage()
            {
                TapeImage = await Resources.Properties.Resources.story_tape.AsBitmapImageAsync();
            }
        }

        private void NavigateToStoryPage(object obj)
        {
            NavigationService.Navigate(typeof(StoryPage), null);
        }

        private void NavigateToOperatorsList(object obj)
        {
            NavigationService.Navigate(typeof(OperatorLists), null);
        }
    }
}
