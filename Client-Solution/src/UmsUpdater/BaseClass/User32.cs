using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace UmsUpdater
{
    public class User32
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ShowWindow(IntPtr hwnd, long cmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int GetProp(IntPtr hwnd, string lpString);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static bool SetProp(IntPtr hwnd, string lpString, int hData);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int RemoveProp(IntPtr hwnd, string lpString);


    }
}
