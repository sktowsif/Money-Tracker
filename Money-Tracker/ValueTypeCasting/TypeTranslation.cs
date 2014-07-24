using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeCasting
{
    public static class TypeTranslation
    {
        public static int GetInt(string strNumValue)
        {
            int intNumValue=0;
            if (int.TryParse(strNumValue, out intNumValue))
                return intNumValue;
            else
                return intNumValue;
        }
        public static decimal GetDecimal(string strNumValue)
        {
            decimal dcmlNumValue = 0;
            if (decimal.TryParse(strNumValue, out dcmlNumValue))
                return dcmlNumValue;
            else
                return dcmlNumValue;
        }
    }
}
