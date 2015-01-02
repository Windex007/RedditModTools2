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
    /// Interaction logic for LittleToggle.xaml
    /// </summary>
    public partial class LittleToggle : UserControlWithClick
    {

        public Dictionary<ToggleButtonState,Rect> imgRects;
        
        public delegate void toggleHovered(LittleToggle lt, int idValue, string hint);
        public event toggleHovered lt_MouseEnter;
        public event toggleHovered lt_MouseExit;

        public string hint 
        {
            get 
            {
                switch(idValue)
                {
                    case 1:
                        return "Truth";
                        break;
                    case 2:
                        return "Pvt. Info";
                        break;
                    case 3:
                        return "Bully";
                        break;
                    case 4:
                        return "Title";
                        break;
                    case 5:
                        return "Story";
                        break;
                    case 6:
                        return "NSFW";
                        break;
                    case 7:
                        return "Meme";
                        break;
                    default:
                        return "??";
                        break;
                }
            }
            private set { }
        }

        public bool isChecked;
        public int idValue { get; set; }
        public LittleToggle()
        {
            InitializeComponent();
            initializeRects();
            isChecked = false;
            setImgState(ToggleButtonState.OFF);
        }

        private void initializeRects()
        {
            imgRects = new Dictionary<ToggleButtonState, Rect>();
            imgRects.Add(ToggleButtonState.OFF, new Rect(0, 0.75, 1, 1));
            imgRects.Add(ToggleButtonState.OFF_HOVER, new Rect(0, 0.5, 1, 1));
            imgRects.Add(ToggleButtonState.ON, new Rect(0, 0.25, 1, 1));
            imgRects.Add(ToggleButtonState.ON_HOVER, new Rect(0, 0, 1, 1));
        }
        private void setImgState(ToggleButtonState state)
        {
            imgBrush.Viewbox = imgRects[state];
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setImgState((isChecked ? ToggleButtonState.OFF_HOVER : ToggleButtonState.ON_HOVER));
            isChecked = !isChecked;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            setImgState((isChecked ? ToggleButtonState.ON_HOVER : ToggleButtonState.OFF_HOVER));
            if(lt_MouseEnter != null)
                lt_MouseEnter(this, idValue, hint);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            setImgState((isChecked ? ToggleButtonState.ON : ToggleButtonState.OFF));
            if(lt_MouseExit != null)
                lt_MouseExit(this, idValue, hint);
        }


    }
    public enum ToggleButtonState
    {
        OFF,
        OFF_HOVER,
        ON,
        ON_HOVER
    }
}
