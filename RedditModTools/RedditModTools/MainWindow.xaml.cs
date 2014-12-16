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

        Subreddit sub;

        public MainWindow()
        {
            InitializeComponent();
            initialize();
        }
        public void initialize()
        {
            
            subreddit = "thatHappened";

            isLoggedIn = false;

            reports = null;
            
        }
        public void populateUnmodded()
        {
            textArea.Text = "";
            

            foreach (Post post in unmoderatedLinks)
                textArea.Text += post.Title + "\n";
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
            if (isLoggedIn)
            {
                Listing<Post> newStuff = sub.GetUnmoderatedLinks();
                if (newStuff != null)
                    unmoderatedLinks = newStuff;

                populateUnmodded();
            }
        }
    }
}
