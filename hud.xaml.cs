
using Microsoft.Win32;
using snagThis.snacks;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace snagThis
{
    /// <summary>
    /// Interaction logic for hud.xaml
    /// </summary>
    public partial class hud : Window
    {
        public Bitmap screenShot = null;

        public hud()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window is loaded
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new snagger().SetWindowTopMost(new WindowInteropHelper(this).Handle);
        }

        /// <summary>
        /// Close Window click event
        /// </summary>
        private void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sets the image holder with the passed bitmap
        /// </summary>
        public void SetScreenShot(Bitmap ss)
        {
            screenShot = ss;
            screenShotHolder.Source = BitmapToImageSource(ss);
        }

        /// <summary>
        /// Turns passed bitmap  to bitmap image for SOURCE
        /// </summary>
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }

        /// <summary>
        /// Automatically save the image to default location with default name
        ///     <action>
        ///         Creates Directory if needed
        ///         Saves picture there with name and datetime
        ///       Show the success snack OR Show the error snack
        ///     </action>
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string savePath = (Properties.Settings.Default.DefaultSaveLocation == "") ? Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\snagThis" : Properties.Settings.Default.DefaultSaveLocation;
            if (!Directory.Exists(savePath))
            {
                try
                {
                    Directory.CreateDirectory(savePath);
                }
                catch
                {
                    //Issue creating directory
                    SnackError error = new SnackError();
                    error.setText("Cannot create directory." + Environment.NewLine + "Check Permissions");
                    error.Show();
                }
            }
            try {
                screenShot.Save(savePath+ @"\snagThis" + DateTime.Now.ToString("yyyymmddMMss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                SnackSuccess success = new SnackSuccess();
                success.setText("Your image has been saved!");
                success.Show();
            }
            catch
            {
                //Issue saving file
                SnackError error = new SnackError();
                error.setText("Issue Saving File!" + Environment.NewLine + "Check Permissions");
                error.Show();
            }
        }
        
        /// <summary>
        /// Save the screenshot to a specific location with a specific name
        ///     <action>
        ///        Shows save file dialog
        ///        When dialog closes it saves screenshot with name and extension
        ///       Show the success snack OR Show the error snack
        ///     </action>
        /// </summary>
        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    screenShot.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    SnackSuccess success = new SnackSuccess();
                    success.setText("Your image has been saved!");
                    success.Show();
                }
                catch
                {
                    //Issue saving file
                    SnackError error = new SnackError();
                    error.setText("Issue Saving File!" + Environment.NewLine + "Check Permissions");
                    error.Show();
                }
            }
        }
        
        /// <summary>
        /// Copy iamge to clipboard
        ///     <action>
        ///       Copy image to clipboard
        ///       Show the success snack OR Show the error snack
        ///     </action>
        /// </summary>
        private void copyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetImage((Image)screenShot);
                SnackSuccess sucess = new SnackSuccess();
                sucess.setText("Your screen shot has been copied!" + Environment.NewLine + "Now you can paste it");
                sucess.Show();
            }
            catch
            {
                SnackError error = new SnackError();
                error.setText("Could Not Copy To Clipboard");
                error.Show();
            }

        }

        /// <summary>
        /// email image is clicked
        ///     <action>
        ///     </action>
        /// </summary>
        private void email_Click(object sender, RoutedEventArgs e)
        {
            //Not implemented
        }

    }//class
}//namespace
