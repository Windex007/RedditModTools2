using RedditModTools.UserControls;
using RedditSharp;
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

namespace RedditModTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Reddit reddit;
        Listing<VotableThing> reports;
        Listing<Post> unmoderatedLinks;

        public string subreddit;
        public bool isLoggedIn;

        List<ItemBar> unModdedBars;

        Subreddit sub;

        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }
        public void initialize()
        {
            
            subreddit = "thatHappenedMods";

            isLoggedIn = false;

            reports = null;

            unModdedBars = new List<ItemBar>();

            unmoderatedContentControl.Back += unmoderatedContentControl_Back;
            
        }

        void unmoderatedContentControl_Back(UserControls.ContentControl sender)
        {
            unmoderatedContentControl.Visibility = System.Windows.Visibility.Hidden;

            foreach (UIElement child in unModeratedStack.Children)
                (child as ItemBar).changeToState(Enums.ItemBarState.FULL);
        }
        public void populateUnmoddedPosts()
        {
            if (isLoggedIn)
            {
                Listing<Post> newStuff = sub.UnmoderatedLinks;
                if (newStuff != null)
                    unmoderatedLinks = newStuff;

                populateUnmoddedBars();
            }       
        }
        public void populateUnmoddedBars()
        {
            //TODO examine if this is really how I want to do this.
            //It probably isn't. This method reeks of pretending to be useful in more than one case.
            foreach(UIElement child in unModeratedStack.Children)
            {
                (child as ItemBar).RemovePressed -= thisBar_RemovePressed;
                (child as ItemBar).ContentPressed -= thisBar_ContentPressed;
            }
            unModeratedStack.Children.Clear();

            ItemBar thisBar;
            foreach (Post post in unmoderatedLinks)
            {
                thisBar = new ItemBar();
                thisBar.populate(post);
                thisBar.RemovePressed += thisBar_RemovePressed;
                thisBar.ContentPressed += thisBar_ContentPressed;
                
                thisBar.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                unModeratedStack.Children.Add(thisBar);
            }
        }
        //We want the selected bar to go to the top
        //to re-order the selected bar to leftmost content orientation
        //to collapse all others
        //to show the content browser and "back" viel over collapsed items
        //to populate the content browser
        void thisBar_ContentPressed(ItemBar sender, Uri uri)
        {
            if ((sender as ItemBar).barState == Enums.ItemBarState.FULL)
            {
                
                //Move selected to top, set proper layouts
                List<ItemBar> tmpPost = new List<ItemBar>();
                tmpPost.Add(sender);
                sender.changeToState(Enums.ItemBarState.COLLAPSED_FOCOUSED);

                foreach (UIElement child in unModeratedStack.Children)
                {
                    if (!tmpPost.Contains(child as ItemBar))
                    {
                        tmpPost.Add(child as ItemBar);
                        (child as ItemBar).changeToState(Enums.ItemBarState.COLLAPSED_UNFOCUSED);
                    }
                }

                unModeratedStack.Children.Clear();

                foreach (ItemBar itemBar in tmpPost)
                    unModeratedStack.Children.Add(itemBar);


                //Do content
                unmoderatedContentControl.Visibility = System.Windows.Visibility.Visible;
                unmoderatedContentControl.loadContent(uri);
                
            }
 
        }

        void thisBar_RemovePressed(ItemBar sender, string fullName, List<int> infractions)
        {
            removePost(fullName, infractions);
        }
  
        public void removePost(string fullname, List<int> infractions)
        {
            Post thingToRemove = (Post)reddit.GetThingByFullname(fullname);
            
            thingToRemove.SetFlair(makeFlairFromInfractions(infractions), "");

            //thingToRemove.Remove();
        }
        public string makeFlairFromInfractions(List<int> infractions)
        {
            string s;
            if(infractions.Count == 0)
            {
                s = "Unspecified Rule";
            }
            else
            {
                s = "Rule";
                if (infractions.Count > 1)
                    s += "s";
                s += ": ";

                for(int i = 0; i < infractions.Count; i++)
                {
                    s += infractions[i].ToString();
                    if (i + 1 < infractions.Count)
                        s += ",";
                }
            }
            return s;
        }
        private void login_loginButton_Click(object sender, RoutedEventArgs e)
        {
            reddit = new Reddit(login_usernameTextbox.Text, login_passwordTextbox.Text);

            isLoggedIn = (reddit.User != null);

            sub = reddit.GetSubreddit(subreddit);

            MessageBox.Show("loggedin");
        }

        private void popButton_Click(object sender, RoutedEventArgs e)
        {
            populateUnmoddedPosts();
        }

        private void full_Click(object sender, RoutedEventArgs e)
        {
            bar.changeToState(Enums.ItemBarState.FULL);
        }

        private void focused_Click(object sender, RoutedEventArgs e)
        {
            bar.changeToState(Enums.ItemBarState.COLLAPSED_FOCOUSED);
        }

        private void unfoc_Click(object sender, RoutedEventArgs e)
        {
            bar.changeToState(Enums.ItemBarState.COLLAPSED_UNFOCUSED);
        }
    }
}
