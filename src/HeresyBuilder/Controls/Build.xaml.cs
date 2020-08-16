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

        public Build()
        {
            InitializeComponent();
            NavigateToHomeworlds(this, null);
        }

        private void NavigateToHomeworlds(object sender, RoutedEventArgs e)
        {
            if (e == null)
            {
                homeworldsView = new HomeworldsView();
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(homeworldsView);
        }
    }
}
