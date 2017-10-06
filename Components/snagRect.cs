using System.Drawing;
using System.Runtime.InteropServices;

namespace snagThis
{
    /// <summary>
    /// SnagRect is the rectangle from the snagged window IntPtr
    /// It literally holds just the info i need for X, Y, height, width, left, and top.
    /// With this info, we can snag that spot on the screen....yay!
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct snagRect
    {
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;

        public snagRect(int Left, int Top, int Right, int Bottom)
        {
            _Left = Left;
            _Top = Top;
            _Right = Right;
            _Bottom = Bottom;
        }

        public int X
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Y
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Height
        {
            get { return _Bottom - _Top; }
            set { _Bottom = value + _Top; }
        }
        public int Width
        {
            get { return _Right - _Left; }
            set { _Right = value + _Left; }
        }
        public static implicit operator Rectangle(snagRect Rectangle)
        {
            return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
        }
        public static implicit operator snagRect(Rectangle Rectangle)
        {
            return new snagRect(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }
    }
}
