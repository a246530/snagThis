using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Threading;

namespace snagThis.snacks
{
    /// <summary>
    /// Interaction logic for SnackError.xaml
    /// </summary>
    public partial class SnackError : Window
    {

        public SnackError()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (desktopWorkingArea.Right - this.Width) / 2;
            this.Top = (desktopWorkingArea.Bottom - this.Height - 16);
            new snagger().SetWindowTopMost(new WindowInteropHelper(this).Handle);
            StartCloseTimer();
        }
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            Close();
        }

        public void setText(string msg)
        {
            errorLabel.Content = msg;
        }

    }//end of class
}//end of namespace
