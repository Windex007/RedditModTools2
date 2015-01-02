using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RedditModTools.UserControls
{
    /// <summary>
    /// Interaction logic for ForwardBackButton.xaml
    /// </summary>
    public partial class ForwardBackButton : UserControlWithClick
    {
        public delegate void ForwardBackButton_MouseStateChangeDelegate(ForwardBackButton fbb, bool isBack);
        public event ForwardBackButton_MouseStateChangeDelegate fbb_MouseEnter;
        public event ForwardBackButton_MouseStateChangeDelegate fbb_MouseExit;
        public event ForwardBackButton_MouseStateChangeDelegate fbb_MouseClick;

        private bool _isBackButton;
        public bool isBackButton
        {
            get
            {
                return _isBackButton;
            }
            set
            {
                _isBackButton = value;
                initializeRects();
            }
        }

        private Rect defaultRect;
        private Rect hoverRect;
        private Rect pressedRect;

        public ForwardBackButton()
        {
            InitializeComponent();
            this.Click += ForwardBackButton_Click;
        }

        void ForwardBackButton_Click(UserControlWithClick sender)
        {
            if (fbb_MouseClick != null)
                fbb_MouseClick(this, isBackButton);
        }
        private void initializeRects()
        {
            if(isBackButton)
            {
                defaultRect = new Rect(0, 0, 1, 1);
                hoverRect = new Rect(0, 0.333, 1, 1);
                pressedRect = new Rect(0, 0.666, 1, 1);
            }
            else
            {
                defaultRect = new Rect(0.5, 0, 1, 1);
                hoverRect = new Rect(0.5, 0.333, 1, 1);
                pressedRect = new Rect(0.5, 0.666, 1, 1);
            }

           
            imgBrush.Viewbox = defaultRect;
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgBrush.Viewbox = pressedRect;
            
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBrush.Viewbox = hoverRect;
            if (fbb_MouseEnter != null)
                fbb_MouseEnter(this, isBackButton);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            clearHover();
            if (fbb_MouseExit != null)
                fbb_MouseExit(this, isBackButton);
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            imgBrush.Viewbox = hoverRect;
        }
        public void clearHover()
        {
            imgBrush.Viewbox = defaultRect;
        }
    }
}
