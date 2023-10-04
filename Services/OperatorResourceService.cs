using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using ArknightsResources.Operators.Models;
using ArknightsResources.Utility;
using Microsoft.Toolkit.Uwp.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Windows.Storage;
using OperatorTextResources = ArknightsResources.Operators.TextResources.Properties.Resources;
using OperatorIllustResources = ArknightsResources.Operators.IllustResources.Properties.Resources;

namespace ArknightsToolkit.Services
{
    internal static class OperatorResourceService
    {
        private static readonly OperatorTextResourceHelper operatorTextResourceHelper = new OperatorTextResourceHelper(OperatorTextResources.ResourceManager);
        private static readonly OperatorIllustResourceHelper operatorIllustResourceHelper = new OperatorIllustResourceHelper(OperatorIllustResources.ResourceManager);

        private static StorageFolder saveFolder;

        public static StorageFolder SaveFolder
        {
            get
            {
                if (saveFolder == null)
                {
                    saveFolder = ApplicationData.Current.LocalCacheFolder.CreateFolderAsync("Operators", CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();
                }
                return saveFolder;
            }
        }

        public static async void GenerateImagesAsync(bool replaceAll = false)
        {
            System.Collections.Immutable.ImmutableDictionary<string, Operator> list = await operatorTextResourceHelper.GetAllOperatorsAsync(GetCultureInfo());
            if (replaceAll)
            {
                foreach (var op in list.Values)
                {
                    foreach (var illust in op.Illustrations)
                    {
                        StorageFile file = await SaveFolder.CreateFileAsync($"{illust.ImageCodename}.png", CreationCollisionOption.OpenIfExists);
                        Image<Bgra32> image = await operatorIllustResourceHelper.GetOperatorIllustrationReturnImageAsync(illust);
                        await image.SaveAsPngAsync(file.Path);
                        image.Dispose();
                    }
                }
            }
            else
            {
                foreach (var op in list.Values)
                {
                    foreach (var illust in op.Illustrations)
                    {
                        if (await SaveFolder.FileExistsAsync($"{illust.ImageCodename}.png"))
                        {
                            continue;
                        }
                        StorageFile file = await SaveFolder.CreateFileAsync($"{illust.ImageCodename}.png");
                        Image<Bgra32> image = await operatorIllustResourceHelper.GetOperatorIllustrationReturnImageAsync(illust);
                        await image.SaveAsPngAsync(file.Path);
                        image.Dispose();
                    }
                }
            }

            Settings.IsImageGenerated = true;
        }

        public static async Task RemoveImagesAsync()
        {
            try
            {
                StorageFolder folder = await ApplicationData.Current.LocalCacheFolder.GetFolderAsync("Operators");
                await folder.DeleteAsync(StorageDeleteOption.PermanentDelete);
                Settings.IsImageGenerated = false;
            }
            catch
            {
                //Do nothing
            }
        }

        private static CultureInfo GetCultureInfo()
        {
            CultureInfo current = CultureInfo.CurrentUICulture;
            return current == AvailableCultureInfos.ChineseSimplifiedCultureInfo || current == AvailableCultureInfos.ChineseTraditionalCultureInfo || current == AvailableCultureInfos.JapaneseCultureInfo || current == AvailableCultureInfos.EnglishCultureInfo || current == AvailableCultureInfos.KoreanCultureInfo
                ? current
                : AvailableCultureInfos.ChineseSimplifiedCultureInfo;
        }
    }
}
