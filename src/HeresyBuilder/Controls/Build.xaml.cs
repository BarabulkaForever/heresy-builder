using HeresyBuilder.Controls.BuildControls;
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

namespace HeresyBuilder.Controls
{
    /// <summary>
    /// Interaction logic for Build.xaml
    /// </summary>
    public partial class Build : UserControl
    {

        private HomeworldsView homeworldsView; 
        private BackgroundsView backgroundsView; 
        private RoleView roleView; 

        public Build()
        {
            InitializeComponent();
            NavigateToHomeworlds(this, null);
        }

        private void NavigateToHomeworlds(object sender, RoutedEventArgs e)
        {
            if (homeworldsView == null)
            {
                homeworldsView = new HomeworldsView();
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(homeworldsView);
        }

        private void NavigateToBackground(object sender, RoutedEventArgs e)
        {
            if (backgroundsView == null)
            {
                backgroundsView = new BackgroundsView();
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(backgroundsView);
        }

        private void NavigateToRole(object sender, RoutedEventArgs e)
        {
            if (roleView == null)
            {
                roleView = new RoleView();
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(roleView);
        }
    }
}
