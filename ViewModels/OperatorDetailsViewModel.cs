using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsToolkit.ViewModels
{
    public class OperatorDetailsViewModel : NotificationObject
    {
        public static event Action OperatorTypeChanged;
        public Operator CurrentOperator { get; set; }
        public DelegateCommand ChangeOperatorTypeCommandByOperatorInfoCommmand { get; set; }

        public OperatorDetailsViewModel()
        {
            ChangeOperatorTypeCommandByOperatorInfoCommmand = new DelegateCommand((object obj) =>
            {
                OperatorInfo operatorInfo = (OperatorInfo)obj;
                OperatorChildrenToClassImageConverter.OperatorType = OperatorChildrenToOperatorImageConverter.OperatorType = GetInfomationFromListOfOperatorInfoHelper.OperatorType = operatorInfo.Type;
                OperatorTypeChanged?.Invoke();
            });
        }
    }
}
