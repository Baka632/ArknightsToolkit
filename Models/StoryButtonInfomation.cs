using ArknightsToolkit.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Models
{
    class StoryButtonInfomation : DependencyObject
    {
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(StoryButtonInfomation), new PropertyMetadata("DEFALUT"));

        public BitmapImage Image
        {
            get => (BitmapImage)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(BitmapImage), typeof(StoryButtonInfomation), new PropertyMetadata(null));



        public NavigationCommand Command
        {
            get => (NavigationCommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(NavigationCommand), typeof(StoryButtonInfomation), new PropertyMetadata(null));
    }
}
