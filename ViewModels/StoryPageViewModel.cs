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
        public ObservableCollection<StoryButtonInfomation> StoryButtonInfoCollection { get; } = new ObservableCollection<StoryButtonInfomation>();

        public StoryPageViewModel()
        {
            #region InitializeCollection
            StoryButtonInfoCollection.Add(new StoryButtonInfomation()
            {
                Title = "主线剧情",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInfomation()
            {
                Title = "Side Story剧情",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInfomation()
            {
                Title = "故事集",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_records.png")),
                Command = null
            });
            StoryButtonInfoCollection.Add(new StoryButtonInfomation()
            {
                Title = "其他",
                Image = new BitmapImage(new Uri($"ms-appx:///Assets/UI/ui_missing.png")),
                Command = null
            });
            #endregion
        }
    }
}
