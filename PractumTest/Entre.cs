using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractumTest
{
    //In United States, Entre usually refers to the main course of the meal but in the other parts of the world, it is used for every part of the meal. 
    //I am using entre for the lack of a better word
    public class Entre
    {
        public EntreCategory DishType { get; set; }
        public string Name { get; set; }
        public bool CanServeMultiple { get; set; }

        public Entre(EntreCategory dishType, string dishname)
        {
            DishType = dishType;
            Name = dishname;
        }
    }
}
