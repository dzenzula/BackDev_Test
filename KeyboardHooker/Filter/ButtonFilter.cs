using KeyboardHooker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardHooker.Filter
{
    public class ButtonFilter
    {
        public bool Filter(string buttonName)
        {
            string[] restrictedButtons = new string[5] {"1", "P", "A", "L", "U"};

            if (restrictedButtons.Contains(buttonName))
                return true;

            return false;
        }
    }
}
