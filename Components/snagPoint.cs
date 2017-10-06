using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace snagThis
{
    public partial class snagPoint
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        public Point snagMousePoint()
        {
            POINT p;
            Point mp = new Point(0, 0);
            if (GetCursorPos(out p))
            {
                mp = new Point(p.X, p.Y);
            }
            return mp;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}