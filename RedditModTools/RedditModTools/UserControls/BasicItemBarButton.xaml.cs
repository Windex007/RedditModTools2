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
    public partial class BasicItemBarButton : UserControlWithClick
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
        private Dictionary<int, LittleToggle> ruleToggles;
        public List<int> getActiveRuleInfractions ()
        {
            List<int> ruleInfractions = new List<int>();
            for(int i = 0; i < ruleToggles.Count; i++)
            {
                if(ruleToggles[i].isChecked)
                    ruleInfractions.Add(i + 1);
            }
            return ruleInfractions;
        }
        private void childMouseExit(LittleToggle lt, int ruleId, string hint)
        {
            buttonLabel.Content = buttonText;
            childHovered = false;
            this.stopBlockingClicks();
        }
        private void childMouseEnter(LittleToggle lt, int ruleId, string hint)
        {
            buttonLabel.Content = hint;
            childHovered = true;
            this.startBlockingClicks();
        }
        public BasicItemBarButton()
        {
            InitializeComponent();
            initializeRects();
            
            childHovered = false;
            initializeRuleToggleDictionary();
            initializeChildrenState();

            this.Click += BasicItemBarButton_Click;
        }
        public void initializeRuleToggleDictionary()
        {
            ruleToggles = new Dictionary<int, LittleToggle>();
            ruleToggles.Add(0, toggleRule1);
            ruleToggles.Add(1, toggleRule2);
            ruleToggles.Add(2, toggleRule3);
            ruleToggles.Add(3, toggleRule4);
            ruleToggles.Add(4, toggleRule5);
            ruleToggles.Add(5, toggleRule6);
            ruleToggles.Add(6, toggleRule7);
        }
        public void BasicItemBarButton_Click(UserControlWithClick sender)
        {
            if (buttonType == ItemBarButtonType.REMOVE)
            {
                clearForwardBackHighlighting();
                setForwardBackVisibility(System.Windows.Visibility.Visible);
            }
            else
            {
                if (ButtonPressed != null)
                    ButtonPressed(this);
            }
        }
        private void initializeChildrenState()
        {
            for(int i = 0; i < ruleToggles.Count; i++)
            {
                ruleToggles[i].lt_MouseEnter += childMouseEnter;
                ruleToggles[i].lt_MouseExit += childMouseExit;
            }



            forwardButton.fbb_MouseEnter += handleForwardBackEnter;
            forwardButton.fbb_MouseExit += handleForwardBackExit;
            forwardButton.fbb_MouseClick += handleForwardBackClick;

            backButton.fbb_MouseEnter += handleForwardBackEnter;
            backButton.fbb_MouseExit += handleForwardBackExit;
            backButton.fbb_MouseClick += handleForwardBackClick;
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
        private void clearForwardBackHighlighting()
        {
            backButton.clearHover();
            forwardButton.clearHover();
        }
        private void handleForwardBackEnter(ForwardBackButton fbb, bool isBack)
        {
            childHovered = true;
            this.startBlockingClicks();
        }
        private void handleForwardBackExit(ForwardBackButton fbb, bool isBack)
        {
            childHovered = false;
            this.stopBlockingClicks();
        }
        private void handleForwardBackClick(ForwardBackButton fbb, bool isBack)
        {
            //Refactor this
            
            if(isBack)
            {
             

                setForwardBackVisibility(System.Windows.Visibility.Collapsed);
                
                childHovered = false;
            }
            else
            {
                
                setForwardBackVisibility(System.Windows.Visibility.Collapsed);
                
                childHovered = false;

                if (ButtonPressed != null)
                    ButtonPressed(this);

           
            }
            this.stopBlockingClicks();

            
            
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
