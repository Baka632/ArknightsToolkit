using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.ViewModels
{
    class StoryPageViewModel : NotificationObject
    {
        public ObservableCollection<StoryButtonInformation> StoryButtonInfoCollection { get; } = new ObservableCollection<StoryButtonInformation>();

        public StoryPageViewModel()
        {
            #region InitializeCollection
            StoryButtonInfoCollection.Add(new StoryButtonInformation()
            {
                Title = "主线剧情",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInformation()
            {
                Title = "Side Story剧情",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInformation()
            {
                Title = "故事集",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_records.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInformation()
            {
                Title = "其他",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            #endregion
        }
    }
}
