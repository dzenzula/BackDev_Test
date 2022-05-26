using KeyboardHooker.Models;
using System.Collections.Generic;
using System.Linq;

namespace KeyboardHooker.Data
{
    public class DataContext
    {
        private static readonly List<ButtonKeyboard> buttons = new List<ButtonKeyboard>();


        public static void AddButton(string name, int code)
        {
            ButtonKeyboard? button = new ButtonKeyboard();
            if (buttons.Any(b => b.Name == name))
            {
                button = buttons.FirstOrDefault(b => b.Name == name);
                button.ClickAmount += 1;
            }
            else
            {
                button = new ButtonKeyboard()
                {
                    Name = name,
                    Code = code,
                    ClickAmount = 1
                };
                buttons.Add(button);
            }
        }

        public List<ButtonKeyboard> GetButtons()
        {
            return buttons;
        }

        public void ClearButtons()
        {
            buttons.Clear();
        }
    }
}
