using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BaseServices
{
    public class ControlTabControlWithShowTabHeaders : TabControl
    {
        /// <summary>   
        /// Gets or sets a value indicating whether the tab headers should be drawn   
        /// </summary>   
        [
        Description("Gets or sets a value indicating whether the tab headers should be drawn"),
        DefaultValue(true)
        ]
        public Boolean _showTabHeaders = true;
        public Boolean ShowTabHeaders
        {
            get { return _showTabHeaders; }
            set { _showTabHeaders = value; }
        }
        

        public ControlTabControlWithShowTabHeaders  ()
            : base()
        {   
        }

        protected override void WndProc(ref Message m)
        {
            //Hide tabs by trapping the TCM_ADJUSTRECT message      
            if (!ShowTabHeaders && m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }
    }
}

//source: http://www.daniweb.com/forums/thread215150.html
