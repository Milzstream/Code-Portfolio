using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Library.Extensions
{
    public static class ExtensionMethods
    {
        //Makes a string into a css class name
        public static String Classify(this String str)
        {
            //Variable
            StringBuilder strB = new StringBuilder("_c");
            String[] split = str.Split(' ');

            foreach (String character in split)
            {
                if (character.Length > 1)
                {
                    strB.Append("_" + character.Trim().Substring(0, 2));
                }
            }

            return strB.ToString();
        }

        //Essentially takes the 1st word in a string and turns it into a css class
        public static String SingleClassify(this String str)
        {
            //Variable
            String cssClass = str.Split(' ')[0];

            return cssClass.ToLower();
        }
    }
}
