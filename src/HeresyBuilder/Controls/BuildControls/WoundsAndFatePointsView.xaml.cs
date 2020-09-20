using HeresyBuilder.ViewModels;
using HeresyBuilder.ViewModels.BuildViewModels;
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

namespace HeresyBuilder.Controls.BuildControls
{
    /// <summary>
    /// Interaction logic for WoundsAndFatePointsView.xaml
    /// </summary>
    public partial class WoundsAndFatePointsView : UserControl
    {
        private Build _parrent;
        public WoundsAndFatePointsView(Build parrent)
        {
            InitializeComponent();
            DataContext = new WoundsAndFatePointsViewModel();
            _parrent = parrent;
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            _parrent.GoNext(DataContext as BaseViewModel);
        }
    }
}
