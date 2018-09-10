using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices.Control
{
    public delegate void ClickEvent(object sender, EventArgs e);
    public delegate void LinkClickedEvent(object sender, LinkLabelLinkClickedEventArgs e);
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);
    public delegate void KeyPressEnter();
}
