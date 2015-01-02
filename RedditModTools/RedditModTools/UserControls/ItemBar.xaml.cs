using RedditModTools.Enums;
using RedditModTools.StaticClasses;
using RedditSharp.Things;
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
    /// Interaction logic for ItemBar.xaml
    /// </summary>
    public partial class ItemBar : UserControl
    {

        public delegate void ItemBar_RemoveEventHandler(ItemBar sender,string fullName, List<int> infractions);
        public event ItemBar_RemoveEventHandler RemovePressed;

        public delegate void ItemBar_ContentEventHandler(ItemBar sender, Uri uri);
        public event ItemBar_ContentEventHandler ContentPressed;

        public delegate void ItemBar_IgnoreEventHandler(ItemBar sender, string fullName);
        public event ItemBar_IgnoreEventHandler IgnorePressed;

        public delegate void ItemBar_ApproveEventHandler(ItemBar sender, string fullName);
        public event ItemBar_ApproveEventHandler ApprovePressed;

        public delegate void ItemBar_SpamEventHandler(ItemBar sender, string fullName);
        public event ItemBar_SpamEventHandler SpamPressed;


        public ItemBarState barState { get; private set; }
        public string redditThingFullName { get; private set; }
        public Uri redditContentUri { get; private set; }
        public bool isSelfPost { get; private set; }
        public string selfPostText { get; private set; }

        public ItemBar()
        {
            InitializeComponent();

            barState = ItemBarState.FULL;

            contentButton.ButtonPressed += contentButton_ButtonPressed;
            removeButton.ButtonPressed += removeButton_ButtonPressed;
            ignoreButton.ButtonPressed += ignoreButton_ButtonPressed;
            approveButton.ButtonPressed += approveButton_ButtonPressed;
            spamButton.ButtonPressed += spamButton_ButtonPressed;
  
        }
        public void populate(Post post)
        {
            contentButton.buttonText = post.Title;
            redditThingFullName = post.FullName;
            redditContentUri = post.Url;
            isSelfPost = post.IsSelfPost;
            selfPostText = (isSelfPost ? post.SelfText : "");
            
        }
        void spamButton_ButtonPressed(BasicItemBarButton sender)
        {
            if (SpamPressed != null)
                SpamPressed(this, this.redditThingFullName);
        }

        void approveButton_ButtonPressed(BasicItemBarButton sender)
        {
            if (ApprovePressed != null)
                ApprovePressed(this, this.redditThingFullName);
        }

        void ignoreButton_ButtonPressed(BasicItemBarButton sender)
        {
            if (IgnorePressed != null)
                IgnorePressed(this, this.redditThingFullName);
        }

        void contentButton_ButtonPressed(BasicItemBarButton sender)
        {
            if (ContentPressed != null)
                ContentPressed(this, redditContentUri);
        }
        
        void removeButton_ButtonPressed(BasicItemBarButton sender)
        {
            printInfractions();
        }
        public void printInfractions()
        {
            List<int> infractions = removeButton.getActiveRuleInfractions();
            if (RemovePressed != null)
                RemovePressed(this, this.redditThingFullName, infractions);
        }
        public void changeToState (ItemBarState newState)
        {
            
            if(barState != newState)
            {
                switch (newState)
                {
                    case ItemBarState.FULL:
                        this.Width = 1200;
                        contentButton.Width = 800;

                        contentButton.Margin = new Thickness(0, 0, 200, 0);
                        approveButton.Margin = new Thickness(0, 0, 100, 0);
                        ignoreButton.Margin = new Thickness(0, 0, 0, 0);
                        break;
                    case ItemBarState.COLLAPSED_UNFOCUSED:
                        contentButton.Width = 0;
                        this.Width = 400;

                        approveButton.Margin = new Thickness(0, 0, 100, 0);
                        ignoreButton.Margin = new Thickness(0, 0, 0, 0);

                        break;
                    case ItemBarState.COLLAPSED_FOCOUSED:
                        this.Width = 1200;
                        contentButton.Width = 800;
                        
                        contentButton.Margin = new Thickness(0,0,0,0);
                        approveButton.Margin = new Thickness(0,0,900,0);
                        ignoreButton.Margin = new Thickness(0,0,800,0);
                        break;
                    default:
                        break;
                }
                barState = newState;
            }
        }


    }
}
