using System;
using System.Windows;
using System.Windows.Controls;

namespace snagThis
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        public settings()
        {
            InitializeComponent();
        }

        private void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetupForm()
        {
            this.PrimaryColorPicker.SelectedValue = Properties.Settings.Default.PrimaryColor;
            this.AccentColorPicker.SelectedValue = Properties.Settings.Default.AccentColor;
           // this.modePicker.SelectedValue = Properties.Settings.Default.ColorMode;

            //Check if default save location has been setup, if not just use the snagthis default location
            saveFolderPath.Text=(Properties.Settings.Default.DefaultSaveLocation == "") ? Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\snagThis" : Properties.Settings.Default.DefaultSaveLocation;

            if (Properties.Settings.Default.AutoFocus)
            {
                AutoFocusTrue.IsChecked = true;
            }
            else
            {
                AutoFocusFalse.IsChecked = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetupForm();
        }

        private void PrimaryColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentColor = Properties.Settings.Default.PrimaryColor;
            try
            {
                string newColor = PrimaryColorPicker.SelectedValue.ToString();
                Properties.Settings.Default.PrimaryColor = newColor;
                new MaterialDesignThemes.Wpf.PaletteHelper().ReplacePrimaryColor(newColor);
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }

        private void modePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mode=modePicker.SelectedValue.ToString();
            try
            {
                Properties.Settings.Default.ColorMode = mode;
                new MaterialDesignThemes.Wpf.PaletteHelper().SetLightDark(mode == "Dark" ? true : false);
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }

        private void AccentColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentColor = Properties.Settings.Default.AccentColor;
            try
            {
                string newColor = AccentColorPicker.SelectedValue.ToString();
                Properties.Settings.Default.AccentColor = newColor;
                new MaterialDesignThemes.Wpf.PaletteHelper().ReplaceAccentColor(newColor);
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }

        private void SelectDefaultSaveLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                {
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    string savePath = dialog.SelectedPath.ToString();
                    saveFolderPath.Text = savePath;
                    Properties.Settings.Default.DefaultSaveLocation = savePath;
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {

            }
        }

        private void AutoFocusTrue_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.AutoFocus = true;
            }
            catch { }
        }

        private void AutoFocusFalse_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.AutoFocus = false;
            }
            catch { }
        }
    }//end of class
}//end of namespace
