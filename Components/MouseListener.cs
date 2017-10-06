using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace snagThis
{
    /// <summary>
    /// MouseListener handles mouse clicks and mouse movement
    /// </summary>
    public static class MouseListener
    {
        public static event EventHandler MouseClick = delegate { };
        public static event EventHandler MouseMovement = delegate { };

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private const int WH_MOUSE_LL = 14;
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }


        public static void Start()
        {
            _hookID = SetHook(_proc);
        }
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }


        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// <summary>
        /// HookCallback
        ///     <action>
        ///        Check if it is a mouse movement or a mouse click or neither
        ///     </action>
        ///     <return>
        ///         IntPtr from CallNextHookEx
        ///     </return>
        /// </summary>
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseClick(null, new EventArgs());
            }
            else if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseMovement(null, new EventArgs());
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        
    }//class
}//namespace
