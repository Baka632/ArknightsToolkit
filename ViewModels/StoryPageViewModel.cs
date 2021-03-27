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

        private BitmapImage backgroundImage;

        public BitmapImage BackgroundImage
        {
            get => backgroundImage;
            set
            {
                backgroundImage = value;
                OnPropertiesChanged();
            }
        }

        public StoryPageViewModel()
        {
            SetImages();

            async void SetImages()
            {
                BackgroundImage = await Resources.Properties.Resources.story_bg3.AsBitmapImageAsync();
                #region InitializeCollection
                StoryButtonInfoCollection.Add(new StoryButtonInfomation()
                {
                    Title = "主线剧情",
                    Image = null,
                    Command = null
                });
                StoryButtonInfoCollection.Add(new StoryButtonInfomation()
                {
                    Title = "Side Story剧情",
                    Image = null,
                    Command = null
                });
                StoryButtonInfoCollection.Add(new StoryButtonInfomation()
                {
                    Title = "故事集",
                    Image = await Resources.Properties.Resources.story_storiescollection.AsBitmapImageAsync(),
                    Command = null
                });
                StoryButtonInfoCollection.Add(new StoryButtonInfomation()
                {
                    Title = "其他",
                    Image = null,
                    Command = null
                });
                #endregion
            }
        }
    }
}
