using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectHelper
{
    public class Common
    {
        public static string GetFileName(string fullPath)
        {
            string[] split = fullPath.Split(new[] { "\\" }, StringSplitOptions.None);
            string rs = split[split.Count() - 1];

            return rs;
        }

    }
}
