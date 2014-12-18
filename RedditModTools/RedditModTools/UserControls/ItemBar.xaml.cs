using RedditModTools.Enums;
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
    /// Interaction logic for ItemBar.xaml
    /// </summary>
    public partial class ItemBar : UserControl
    {

        public ItemBarState barState { get; private set; }

        public ItemBar()
        {
            InitializeComponent();

            barState = ItemBarState.FULL;
  
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
