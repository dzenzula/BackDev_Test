using SQLite;

namespace KeyboardHooker.Models
{

    public class ButtonKeyboard
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }

        [Unique]
        public int Code { get; set; }

        public int ClickAmount { get; set; }
    }
}
