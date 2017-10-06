using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using snagThis.snacks;

namespace snagThis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SnagThisWindow : Window
    {
        DateTime previousTime = DateTime.UtcNow;
        System.Windows.Forms.NotifyIcon notifyIcon;

        /// <summary>
        /// Initiale Main Window
        ///     <action>
        ///        Intialize
        ///        Setup the notify icon in bottom right by time
        ///        Set colors and themes based on app settings
        ///         Add menu items (Settings And Exit) to notify icon
        ///     </action>
        /// </summary>
        public SnagThisWindow()
        {
            InitializeComponent();

            System.Windows.Forms.ContextMenu cm = new System.Windows.Forms.ContextMenu();
            cm.MenuItems.Add(new System.Windows.Forms.MenuItem("Settings", MenuItemSettings_Click));
            cm.MenuItems.Add(new System.Windows.Forms.MenuItem("Exit", ExitSettings_Click));

            new MaterialDesignThemes.Wpf.PaletteHelper().ReplacePrimaryColor(Properties.Settings.Default.PrimaryColor);
            new MaterialDesignThemes.Wpf.PaletteHelper().ReplaceAccentColor(Properties.Settings.Default.AccentColor);
            new MaterialDesignThemes.Wpf.PaletteHelper().SetLightDark((Properties.Settings.Default.ColorMode == "Dark") ? true: false);


            notifyIcon = new System.Windows.Forms.NotifyIcon()
            {
                Icon = new System.Drawing.Icon("resources\\icon.ico"),
                Visible = true,
                ContextMenu=cm
            };
        }
        /// <summary>
        /// Exit the application
        ///     <action>
        ///        Dispose of notify icon
        ///        Shuwdown application
        ///     </action>
        /// </summary>
        private void ExitSettings_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Show Settings Window
        /// </summary>
        private void MenuItemSettings_Click(Object sender, System.EventArgs e)
        {
            new settings().Show();
        }
        /// <summary>
        /// If Window Loses Focus this will take and set the window at the top.
        ///     <action>
        ///        Set this.Handle to be the topmost window in Z-index
        ///     </action>
        /// </summary>
        private void Window_Deactivated(object sender, EventArgs e)
        {
            new snagger().SetWindowTopMost(new WindowInteropHelper(this).Handle);
        }


        /// <summary>
        /// Prime the camera
        ///     <action>
        ///         MouseHook action to mouseClickEvent will capture next click by user
        ///         Handle "bring window to focus" if it's enabled
        ///         Change background of camera to green
        ///     </action>
        /// </summary>
        private void primeCapture_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MouseListener.Start();
                MouseListener.MouseClick += new EventHandler(takeScreenShot);
                if (Properties.Settings.Default.AutoFocus == true)
                {
                    MouseListener.MouseMovement += new EventHandler(bringWindowToFocus);
                }
                ((SnagThisWindow)Application.Current.MainWindow).Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(76, 175, 80));
            }
            catch
            {

            }
        }


        /// <summary>
        /// This brings the window the mouse is currently on into focus, setting it at the topmost z index.
        /// </summary>
        private void bringWindowToFocus(object sender, EventArgs e)
        {
            new snagger().SetWindowFocus();
        }


        /// <summary>
        /// Mouse Click event for getting picture. This means trigger was primed and the screenshot needs generated.
        ///     <action>
        ///         Unhooks MouseHook action from event handler to prevent fast clicks generating 2nd call
        ///         Initiate snagger class
        ///         Execute snagThis() in snagger.cs
        ///         Show the HUD
        ///         Change background color of mainwindow back to red
        ///     </action>
        /// </summary>
        private void takeScreenShot(object sender, EventArgs e)
        {
           
            try {
                MouseListener.Stop();
                MouseListener.MouseClick -= new EventHandler(takeScreenShot);
                MouseListener.MouseMovement -= new EventHandler(bringWindowToFocus);
                Bitmap screenShot = null;
                screenShot = new snagger().snagthis();
                hud hud = new hud();
                hud.SetScreenShot(screenShot);
                hud.Show();
            }
            catch
            {
                //could not snag image
                SnackError error = new SnackError();
                error.setText("Issue Taking Screen Shot.");
                error.Show();
            }
            ((SnagThisWindow)Application.Current.MainWindow).Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(244, 67, 54));
            
        }

    }//end of class
}//end of namespace
