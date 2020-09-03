using HeresyBuilder.ViewModels;
using HeresyBuilder.ViewModels.BuildViewModels;
using System.Windows;
using System.Windows.Controls;
namespace HeresyBuilder.Controls.BuildControls
{
    /// <summary>
    /// Interaction logic for AptitudesView.xaml
    /// </summary>
    public partial class AptitudesView : UserControl
    {
        private Build _parrent;
        public AptitudesView(Build parrent)
        {
            InitializeComponent();
            DataContext = new AptitudesViewModel();
            _parrent = parrent;
        }
        private void NextClick(object sender, RoutedEventArgs e)
        {
            _parrent.GoNext(DataContext as BaseViewModel);
        }
    }
}
