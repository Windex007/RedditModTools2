using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RedditModTools.UserControls
{
    public class UserControlWithClick : UserControl
    {
        private bool mouseDown = false;
        private bool blockMouseChanges = false;
        public delegate void UserControlWithClick_ClickEventHandler(UserControlWithClick sender);
        public event UserControlWithClick_ClickEventHandler Click;

        public UserControlWithClick()
        {
            this.MouseDown += userControlWithClick_mouseDown;
            this.MouseUp += userControlWithClick_mouseUp;
            this.MouseLeave += userControlWithClick_mouseLeave;
        }
        private void userControlWithClick_mouseDown(object sender, MouseEventArgs e)
        {
            if(!blockMouseChanges)
                mouseDown = true;
        }
        private void userControlWithClick_mouseUp(object sender, MouseEventArgs e)
        {
            if(mouseDown && !blockMouseChanges)
            {
                mouseDown = false;
                if (Click != null)
                    Click(this);
            }
        }
        private void userControlWithClick_mouseLeave(object sender, MouseEventArgs e)
        {
            if(!blockMouseChanges)
                mouseDown = false;
        }
        public void clearClickBool()
        {
            mouseDown = false;
        }
        public void startBlockingClicks()
        {
            blockMouseChanges = true;
        }
        public void stopBlockingClicks()
        {
            blockMouseChanges = false;
        }
    }
}
