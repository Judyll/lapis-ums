using System;
using System.Runtime.InteropServices;

namespace UmsUpdater
{
    public class UserInstance 
    {
        private static string myPropertyName = "USERNAME." + System.Environment.UserName;

        private IntPtr handle = IntPtr.Zero;
       
        public UserInstance(IntPtr hWin)
        {
            this.handle = hWin;
            User32.SetProp(handle, myPropertyName, (int)hWin);
        }

        static public bool IsSameUser(IntPtr pWin)
        {
            if ((int)pWin == 0)
            {
                return true;
            }
            else
            {
                int ptr = User32.GetProp(pWin, myPropertyName);
                return (ptr != 0);
            }
        }
    }
}
