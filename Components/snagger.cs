using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace snagThis
{
    /// <summary>
    /// snagger does all my snagging.
    /// It extends the pInvokeFunctions class which holds...well all the damn pinvoke functions i want to use.
    /// </summary>
    class snagger  : pInvokeFunctions
    {
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        /// <summary>
        /// This function initiates the printWindow after getting mouse point and window handle
        ///     <action>
        ///        Get mouse position
        ///        Get IntPtr of window from mouse position
        ///        Send to PrintWindowFunction
        ///     </action>
        ///     <returns>
        ///         Snagged Bitmap
        /// </returns>
        /// </summary>
        public Bitmap snagthis()
        {
            return PrintWindow(getWindowHandleFromSnaggedPoint(getMousePos()));
        }


        /// <summary>
        ///     <action>
        ///       Get mouse position
        ///       Get window handle from mouse position
        ///       Populate window rectangle from window info
        ///     </action>
        ///     <return>
        ///         snagRect (Size and position of the window to snag)
        ///     </return>
        /// </summary>
        public snagRect snagWindowRect()
        {
            snagRect sR;
            GetWindowRect(getWindowHandleFromSnaggedPoint(getMousePos()), out sR);
            return sR;
        }


        /// <summary>
        ///     <action>
        ///         Get mouse position
        ///         Get window handle from mouse position
        ///         Find parent IntPtr
        ///         Pass to function SetForegroundWindow for processing
        ///     </action>
        ///     <overload>
        ///         Take passed IntPtr of window and set it to foreground    
        ///     </overload>
        /// </summary>
        public void SetWindowFocus()
        {
            SetForegroundWindow(findParent(getWindowHandleFromSnaggedPoint(getMousePos())));
        }
        public void SetWindowFocus(IntPtr window)
        {
            SetForegroundWindow(window);
        }

        /// <summary>
        ///     <action>
        ///         Set Passed window IntPtr to topmost z index
        ///     </action>
        /// </summary>
        public void SetWindowTopMost(IntPtr window)
        {
            SetWindowPos(window, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
        }


        /// <summary>
        ///     <action>
        ///         Get mouse point using snagPoint
        ///     </action>
        /// </summary>
        private Point getMousePos()
        {
            return new snagPoint().snagMousePoint();
        }


        /// <summary>
        ///     <action>
        ///         Get window IntPtr from the point 
        ///     </action>
        /// </summary>
        private IntPtr getWindowHandleFromSnaggedPoint(Point p)
        {
            return WindowFromPoint(p);
        }


        /// <summary>
        ///     <action>
        ///         Create rectangle from WindowToPrint IntPtr
        ///         Create new bitmap and graphics vars and populate
        ///         Send them all to a task and start it for processing
        ///     </action>
        ///     <returns>
        ///         Bitmap screenshot of clicked application
        /// </returns>
        /// </summary>
        private Bitmap PrintWindow(IntPtr WindowToPrint)
        {
            snagRect sR;
            GetWindowRect(findParent(WindowToPrint), out sR);
            Bitmap printscreen = new Bitmap(sR.Width, sR.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            Task<Bitmap> screenShot = Task<Bitmap>.Factory.StartNew(() =>
            {
                return getScreenShot(graphics, sR, printscreen);
            });
            Bitmap screenShotImage = screenShot.Result;
            Thread.Sleep(10);
            return screenShotImage;
        }


        /// <summary>
        ///     <action>
        ///         Sleep for 70 milliseconds to give time for window to focus
        ///         Not sure what that graphics is for but without it, image is just black when i return bitmap
        ///     </action>
        ///     <returns>
        ///         Bitmap image
        /// </returns>
        /// </summary>
        private Bitmap getScreenShot(Graphics graphics, snagRect rc, Bitmap printscreen)
        {
            Thread.Sleep((Properties.Settings.Default.AutoFocus == true) ? 70 : 500);
            graphics.CopyFromScreen(rc.X, rc.Y, 0, 0, printscreen.Size);
            return printscreen;
        }


        /// <summary>
        ///     <action>
        ///         Get mouse point using snagPoint
        ///     </action>
        ///     <return>
        ///     
        ///     </return>
        /// </summary>
        private IntPtr findParent(IntPtr potentialChild)
        {
            while (GetParent(potentialChild) != IntPtr.Zero)
            {
                potentialChild = GetParent(potentialChild);
            }
            return potentialChild;
        }



    }//end of class
}//end of namespace
