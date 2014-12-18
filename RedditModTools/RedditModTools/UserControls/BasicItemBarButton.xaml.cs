using RedditModTools.StaticClasses;
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
    /// Interaction logic for BasicItemBarButton.xaml
    /// </summary>
    public partial class BasicItemBarButton : UserControl
    {
        public delegate void BasicItemBarButton_PressedEventHandler(BasicItemBarButton sender);
        public event BasicItemBarButton_PressedEventHandler ButtonPressed;

        private ItemBarButtonType _buttonType;
        public ItemBarButtonType buttonType { 
            get 
            {
                return _buttonType;
            }
            set 
            {
                _buttonType = value;
                initializeRects();
            }
        }
        public Rect hoverRect { get; private set; }
        public Rect defaultRect { get; private set; }
        public Rect pressedRect { get; private set; }
        private String _buttonText;
        public String buttonText {
            get
            {
                return _buttonText;
            }
            set 
            {
                _buttonText = value;
                buttonLabel.Content = buttonText;
            }
        }
        public bool childHovered { get; private set; }

        private void childMouseExit(LittleToggle lt, int ruleId, string hint)
        {
            buttonLabel.Content = buttonText;
            childHovered = false;
        }
        private void childMouseEnter(LittleToggle lt, int ruleId, string hint)
        {
            buttonLabel.Content = hint;
            childHovered = true;
        }
        public BasicItemBarButton()
        {
            InitializeComponent();
            initializeRects();
            
            childHovered = false;
            initializeChildEvents();
        }
        private void initializeChildEvents()
        {
            toggleRule1.lt_MouseEnter += childMouseEnter;
            toggleRule2.lt_MouseEnter += childMouseEnter;
            toggleRule3.lt_MouseEnter += childMouseEnter;
            toggleRule4.lt_MouseEnter += childMouseEnter;
            toggleRule5.lt_MouseEnter += childMouseEnter;
            toggleRule6.lt_MouseEnter += childMouseEnter;
            toggleRule7.lt_MouseEnter += childMouseEnter;

            toggleRule1.lt_MouseExit += childMouseExit;
            toggleRule2.lt_MouseExit += childMouseExit;
            toggleRule3.lt_MouseExit += childMouseExit;
            toggleRule4.lt_MouseExit += childMouseExit;
            toggleRule5.lt_MouseExit += childMouseExit;
            toggleRule6.lt_MouseExit += childMouseExit;
            toggleRule7.lt_MouseExit += childMouseExit;

            forwardButton.fbb_MouseEnter += handleForwardBackEnter;
            forwardButton.fbb_MouseExit += handleForwardBackExit;
            forwardButton.fbb_MouseClick += handleForwardBackDown;

            backButton.fbb_MouseEnter += handleForwardBackEnter;
            backButton.fbb_MouseExit += handleForwardBackExit;
            backButton.fbb_MouseClick += handleForwardBackDown;
        }
        private void initializeRects()
        {
            switch (buttonType)
            {
                case ItemBarButtonType.SPAM:
                    defaultRect = new Rect(0, 0, 1, 1);
                    hoverRect = new Rect(0, 0.333, 1, 1);
                    pressedRect = new Rect(0, 0.666, 1, 1);
                    break;
                case ItemBarButtonType.REMOVE:
                    defaultRect = new Rect(100.0/1200.0, 0, 1, 1);
                    hoverRect = new Rect(100.0 / 1200.0, 0.333, 1, 1);
                    pressedRect = new Rect(100.0 / 1200.0, 0.666, 1, 1);
                    setRuleButtonVisiblity(System.Windows.Visibility.Visible);
                    break;
                case ItemBarButtonType.CONTENT:
                    defaultRect = new Rect(200.0 / 1200.0, 0, 1, 1);
                    hoverRect = new Rect(200.0 / 1200.0, 0.333, 1, 1);
                    pressedRect = new Rect(200.0 / 1200.0, 0.666, 1, 1);
                    break;
                case ItemBarButtonType.IGNORE:
                    defaultRect = new Rect(1100.0 / 1200.0, 0, 1, 1);
                    hoverRect = new Rect(1100.0 / 1200.0, 0.333, 1, 1);
                    pressedRect = new Rect(1100.0 / 1200.0, 0.666, 1, 1);
                    break;
                case ItemBarButtonType.APPROVE:
                    defaultRect = new Rect(1000.0 / 1200.0, 0, 1, 1);
                    hoverRect = new Rect(1000.0 / 1200.0, 0.333, 1, 1);
                    pressedRect = new Rect(1000.0 / 1200.0, 0.666, 1, 1);
                    break;
                default:
                    break;
            }
            bgBrush.Viewbox = defaultRect;
        }
        private void setRuleButtonVisiblity(System.Windows.Visibility visibility)
        {
            toggleRule1.Visibility = visibility;
            toggleRule2.Visibility = visibility;
            toggleRule3.Visibility = visibility;
            toggleRule4.Visibility = visibility;
            toggleRule5.Visibility = visibility;
            toggleRule6.Visibility = visibility;
            toggleRule7.Visibility = visibility; 
        }
        private void setForwardBackVisibility(System.Windows.Visibility visibility)
        {
            backButton.Visibility = visibility;
            forwardButton.Visibility = visibility;
        }
        private void handleForwardBackEnter(ForwardBackButton fbb, bool isBack)
        {
            childHovered = true;
        }
        private void handleForwardBackExit(ForwardBackButton fbb, bool isBack)
        {
            childHovered = false;
        }
        private void handleForwardBackDown(ForwardBackButton fbb, bool isBack)
        {
            if(isBack)
            {
                setForwardBackVisibility(System.Windows.Visibility.Collapsed);
                childHovered = false;
            }
            else
            {
                if (ButtonPressed != null)
                    ButtonPressed(this);
            }
        }
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            bgBrush.Viewbox = hoverRect;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!childHovered)
            { 
                bgBrush.Viewbox = pressedRect;

                if(buttonType == ItemBarButtonType.REMOVE)
                {
                    setForwardBackVisibility(System.Windows.Visibility.Visible);
                }
                else
                {
                    if (ButtonPressed != null)
                        ButtonPressed(this);
                }
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            bgBrush.Viewbox = defaultRect;
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bgBrush.Viewbox = hoverRect;
        }
    }
    public enum ItemBarButtonType
    {
        SPAM,
        REMOVE,
        CONTENT,
        IGNORE,
        APPROVE
    }
}
