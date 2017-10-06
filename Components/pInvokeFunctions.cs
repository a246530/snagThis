using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace snagThis
{
    /// <summary>
    /// pInvokeFunctions is just a class with all the pinvoke based functions that are used.
    /// </summary>
    public class pInvokeFunctions
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 NOREDRAW = 0x0008;
        const UInt32 ASYNCWINDOWPOS = 0x4000;
        const UInt32 DEFERERASE = 0x2000;
        const UInt32 FRAMECHANGED = 0x0020;
        const UInt32 HIDEWINDOW = 0x0080;
        const UInt32 NOACTIVATE = 0x0010;
        const UInt32 NOCOPYBITS = 0x0100;
        const UInt32 NOMOVE = 0x0002;
        const UInt32 NOOWNERZORDER = 0x0200;
        const UInt32 NOSENDCHANGING = 0x0400;
        const UInt32 NOSIZE = 0x0001;
        const UInt32 NOZORDER = 0x0004;
        const UInt32 SHOWWINDOW = 0x0040;
        const UInt32 DRAWFRAME = 0x0020;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        const UInt32 HIGHLIGHT_FLAGS = SWP_NOMOVE | SWP_NOSIZE | NOREDRAW | NOOWNERZORDER;
        

       
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(System.Drawing.Point p);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out snagRect lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
    }
}
