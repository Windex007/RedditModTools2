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
    /// Interaction logic for ContentControl.xaml
    /// </summary>
    public partial class ContentControl : UserControl
    {
        public delegate void ContentControl_BackEventHandler(ContentControl sender);
        public event ContentControl_BackEventHandler Back;
        public ContentControl()
        {
            InitializeComponent();
        }
        //This is how we load up self post or comments
        public void loadContent(string text)
        {
            //TODO actually build up a formatted thing instead of using the web browser.

            webBrowser.NavigateToString(text);
        }
        //This is how we load up images
        public void loadContent(Uri uri)
        {
            //TODO tear into common image sharing urls to dig out the base image we want to see

            webBrowser.Navigate(uri);
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Back != null)
                Back(this);
        }
    }
}
