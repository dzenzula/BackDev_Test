using KeyboardHooker.Data;
using KeyboardHooker.Handlers;
using KeyboardHooker.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KeyboardHooker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int time = 60;
        private LowLevelKeyboardListener? _listener;
        private SqliteHandler _sqliteHandler;
        private DispatcherTimer _dispatcherTimer;
        private TransferDataHandler _transferDataHandler;
        private DataContext _context;

        public MainWindow()
        {
            InitializeComponent();

            _context = new DataContext();
            _dispatcherTimer = new DispatcherTimer();
            _transferDataHandler = new TransferDataHandler();
            _sqliteHandler = new SqliteHandler(_context, _transferDataHandler);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();

            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            _dispatcherTimer.Start();
        }

        private void _listener_OnKeyPressed(object sender, string e)
        {
            this.textBlock.Text += e;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                _sqliteHandler.SqlSaveButtons();
                time = 60;
                lblTimer.Content = string.Format($"{time}");
                lblTextSave.Content = "Buttons saved!";
            }
            else
            {
                time--;
                lblTimer.Content = string.Format($"{time}");
                lblTextSave.Content = "";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            _transferDataHandler.TransferJson(_context.GetButtons());
        }
    }
}
