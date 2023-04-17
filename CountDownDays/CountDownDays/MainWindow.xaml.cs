using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CountDownDays
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Methods methods = new Methods();
        SettingsWindow settingsWindow = new SettingsWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!methods.ReadAndInitApp(TitleTextBlk, DaysTextBlk, this))
            {
                TitleTextBlk.Text = "Null";
                DaysTextBlk.Text = "Err";
            }


            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMinutes(5)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!methods.ReadAndInitApp(TitleTextBlk, DaysTextBlk, this))
            {
                TitleTextBlk.Text = "Null";
                DaysTextBlk.Text = "Err";
            }
        }
    }
}
