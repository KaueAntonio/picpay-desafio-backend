using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Infrasctructure.Utils
{
    public static class StringOperations
    {
        public static string OnlyNumbers(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
