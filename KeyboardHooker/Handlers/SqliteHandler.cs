using SQLite;
using System.Collections.Generic;
using System.Linq;
using KeyboardHooker.Data;
using KeyboardHooker.Models;
using KeyboardHooker.Handlers;

namespace KeyboardHooker
{
    public class SqliteHandler
    {
        private readonly DataContext _context;
        private readonly TransferDataHandler _transferDataHandler;

        public SqliteHandler(DataContext context, TransferDataHandler transferDataHandler)
        {
            _context = context;
            _transferDataHandler = transferDataHandler;
        }

        public void SqlSaveButtons()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<ButtonKeyboard>();

                var list = connection.Query<ButtonKeyboard>("SELECT * FROM ButtonKeyboard");

                foreach (ButtonKeyboard button in _context.GetButtons())
                {
                    if (list.Any(l => l.Name == button.Name))
                    {
                        var lbtn = list.FirstOrDefault(l => l.Name == button.Name);
                        lbtn.ClickAmount += button.ClickAmount;
                        connection.Update(lbtn);
                    }
                    else
                    {
                        connection.Insert(button);
                    }
                }

                _transferDataHandler.TransferJson(_context.GetButtons());

                _context.ClearButtons();
            }
        }
    }
}
