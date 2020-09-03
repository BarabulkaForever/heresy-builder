using HeresyBuilder.Controls.BuildControls;
using HeresyBuilder.Singleton;
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
        private CharacteristicsView characteristicsView; 
        private AptitudesView aptitudesView; 

        public Build()
        {
            InitializeComponent();
            NavigateToHomeworlds(this, null);
        }

        private void NavigateToHomeworlds(object sender, RoutedEventArgs e)
        {
            if (homeworldsView == null)
            {
                homeworldsView = new HomeworldsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(homeworldsView);
        }

        private void NavigateToBackground(object sender, RoutedEventArgs e)
        {
            if (backgroundsView == null)
            {
                backgroundsView = new BackgroundsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(backgroundsView);
        }

        private void NavigateToRole(object sender, RoutedEventArgs e)
        {
            if (roleView == null)
            {
                roleView = new RoleView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(roleView);
        }

        private void NavigateToCharacteristics(object sender, RoutedEventArgs e)
        {
            if (characteristicsView == null)
            {
                characteristicsView = new CharacteristicsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(characteristicsView);
        }

        private void NavigateToAptitudes(object sender, RoutedEventArgs e)
        {
            if (aptitudesView == null)
            {
                aptitudesView = new AptitudesView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(aptitudesView);
        }

        public void GoNext(BaseViewModel baseViewModel)
        {
            if (baseViewModel is HomeWorldViewModel)
            {
                NavigateToBackgroundTab.IsEnabled = true;
                NavigateToBackgroundTab.IsChecked = true;
                NavigateToBackground(this, null);
                CurrentCharacterCreationData.Instance.World = (baseViewModel as HomeWorldViewModel).Homeworld;
            }
            else if (baseViewModel is BackgroundsViewModel)
            {
                NavigateToRoleTab.IsEnabled = true;
                NavigateToRoleTab.IsChecked = true;
                NavigateToRole(this, null);
                CurrentCharacterCreationData.Instance.Background = (baseViewModel as BackgroundsViewModel).Background;
            }
            else if (baseViewModel is RolesViewModel)
            {
                NavigateToCharacteristicsTab.IsEnabled = true;
                NavigateToCharacteristicsTab.IsChecked = true;
                NavigateToCharacteristics(this, null);
                CurrentCharacterCreationData.Instance.Role = (baseViewModel as RolesViewModel).Role;
            }
            else if (baseViewModel is CharacteristicsViewModel)
            {
                if ((baseViewModel as CharacteristicsViewModel).Valid)
                {
                    NavigateToAptitudesTab.IsEnabled = true;
                    NavigateToAptitudesTab.IsChecked = true;
                    (baseViewModel as CharacteristicsViewModel).SaveCharacteristics();
                    NavigateToAptitudes(this, null);
                }
            }
        }
    }
}
