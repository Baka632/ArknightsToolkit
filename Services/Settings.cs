using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ArknightsToolkit.Services
{
    /// <summary>
    /// 为应用程序的设置提供属性
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// 访问本地设置的实例
        /// </summary>
        private static readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        static bool _IsImageGenerated;

        /// <summary>
        /// 初始化Settings类
        /// </summary>
        static Settings()
        {
            switch (localSettings.Values["IsImageGenerated"])
            {
                case null:
                    _IsImageGenerated = false;
                    localSettings.Values["IsImageGenerated"] = false;
                    break;
                default:
                    _IsImageGenerated = (bool)localSettings.Values["IsImageGenerated"];
                    break;
            }
        }

        public static bool IsImageGenerated
        {
            get => _IsImageGenerated;
            set
            {
                _IsImageGenerated = value;
                localSettings.Values["IsImageGenerated"] = value;
            }
        }
    }
}
