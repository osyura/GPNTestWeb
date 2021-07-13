using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNTestWeb.Model.Enums
{
	public class  EnumExtensions
	{
        public static Dictionary<string,int> GetValues<T>()
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {

                //For each value of this enumeration, add a new EnumValue instance
                values.Add(Enum.GetName(typeof(T), itemType), (int)itemType);
            }
            return values;
        }
    }
}
