using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KeyboardHooker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string dbName = "Keys.db";
        static string folderPath = ".\\";
        public static string databasePath = System.IO.Path.Combine(folderPath, dbName);
    }
}
