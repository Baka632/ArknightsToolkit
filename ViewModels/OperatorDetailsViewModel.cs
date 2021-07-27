using ArknightsResources.Models;
using ArknightsResources.Models.WindowsRuntime;
using ArknightsResources.Models.WindowsRuntime.Operators;
using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsToolkit.ViewModels
{
    public class OperatorDetailsViewModel : NotificationObject
    {
        public Operator CurrentOperator { get; set; }

        public OperatorDetailsViewModel()
        {

        }
    }
}
