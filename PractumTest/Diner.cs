using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractumTest
{
    public class Diner
    {
        public IDictionary<TimeOfDay, IDictionary<EntreCategory, Entre>> Menus;

        public string Serve(string input)
        {

            var tokens = input.Split(',');
            if (tokens.Length < 2)
                throw new ArgumentOutOfRangeException("Invalid number of arguments");
            

            var timeOfDay = tokens[0];
            var list = new List<string>();
            for (int ii = 1; ii < tokens.Length; ii++)
                list.Add(tokens[ii]);

            list.Sort();

            var sb = new StringBuilder();
            EntreCategory lastcategory = EntreCategory.Invalid;
            TimeOfDay enumTimeOfDay;

            if (!Enum.TryParse<TimeOfDay>(timeOfDay, true, out enumTimeOfDay))
                throw new ArgumentException("Invalid Time of Day");

            var menus = Menus[enumTimeOfDay];
            var counter = 1;
            //traverse the token list to build the string
            foreach (string element in list)
            {
                EntreCategory category;
                //check the error condition
                if (!Enum.TryParse<EntreCategory>(element, out category) || category == EntreCategory.Invalid)
                {
                    if (counter > 1)
                    {
                        sb.Append("(x" + counter + ")");
                        counter = 1;
                    }
                    sb.Append((sb.Length == 0 ? string.Empty : ",") + "error");
                    break;
                }

                Entre entre;
                if (!menus.TryGetValue(category, out entre))
                {
                    if (counter > 1)
                    {
                        sb.Append("(x" + counter + ")");
                        counter = 1;
                    }
                    sb.Append((sb.Length == 0 ? string.Empty : ",") + "error");
                    break;
                }

                //check for repeated entres that are repeatable
                if (lastcategory == category && entre.CanServeMultiple)
                {
                    counter++;
                    continue;
                }
                else if (counter > 1)
                {
                    sb.Append("(x" + counter + ")");
                    counter = 1;
                }
                //check if the entre is repeated while it is not repeatable
                if (lastcategory == category && !entre.CanServeMultiple)
                {
                    sb.Append((sb.Length == 0 ? string.Empty : ",") + "error");
                    break;
                }
                else
                    //Add to the string
                    sb.Append((sb.Length == 0 ? string.Empty : ",") + entre.Name.ToLower());
                
                lastcategory = category;
            }

            if (counter > 1)
            {
                sb.Append("(x" + counter + ")");
                counter = 1;
            }

            return sb.ToString();
        }
    }
}
