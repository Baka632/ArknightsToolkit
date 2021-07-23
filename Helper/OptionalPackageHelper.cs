using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace ArknightsToolkit.Helper
{
    public static class OptionalPackageHelper
    {
        public const string OPERATOR_PACKAGE_NAME = "7966604e-c297-4ae8-a58f-106d5f765119";

        public static bool CheckIfOperatorPackageAvailable()
        {
            Package mainPackage = Package.Current;
            var packages = mainPackage.Dependencies;
            return packages.Any((package) => package.IsOptional && package.Status.VerifyIsOK());
        }

        /// <summary>
        /// 返回干员包
        /// </summary>
        /// <returns>一个干员包,如果包未安装,则返回null</returns>
        public static Package GetOperatorPackage()
        {
            Package mainPackage = Package.Current;
            var dependenciesPackages = mainPackage.Dependencies;
            IEnumerable<Package> opPackages = from package in dependenciesPackages where package.Id.Name == OPERATOR_PACKAGE_NAME
                                                                                         && package.Status.VerifyIsOK() select package;
            Package opPackage = opPackages.FirstOrDefault();
            return opPackage;
        }
    }
}
