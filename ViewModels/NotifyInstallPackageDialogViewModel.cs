using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArknightsToolkit.Commands;
using Windows.Foundation;
using Windows.Services.Store;

namespace ArknightsToolkit.ViewModels
{
    internal sealed class NotifyInstallPackageDialogViewModel : NotificationObject
    {
        private string _PackageName;

        public string PackageName
        {
            get => $"{_PackageName}";
            set
            {
                _PackageName = $"\"{value}\"";
                OnPropertiesChanged();
            }
        }
    }
}
