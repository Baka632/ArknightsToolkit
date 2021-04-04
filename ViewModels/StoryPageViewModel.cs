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
            Initialize();

            async void Initialize()
            {
                BackgroundImage = await Resources.Resource.ui_story_background3.AsBitmapImageAsync();
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
                    Image = await Resources.Resource.ui_records.AsBitmapImageAsync(),
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
