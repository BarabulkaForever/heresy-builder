using HeresyBuilder.Controls.BuildControls;
using HeresyBuilder.Controls.Dialogs;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
using HeresyBuilder.ViewModels;
using HeresyBuilder.ViewModels.BuildViewModels;
using HeresyBuilder.ViewModels.DialogViewMoldels;
using MaterialDesignThemes.Wpf;
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
        private TalentsView talentsView; 
        private EquipmentView equipmentView; 
        private SkillsView skillsView; 
        private WoundsAndFatePointsView woundsAndFatePointsView;
        private FileAccessService _fileAccessService;

        public Build()
        {
            InitializeComponent();
            NavigateToHomeworlds(this, null);
            _fileAccessService = new FileAccessService();
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

        private void NavigateToTalents(object sender, RoutedEventArgs e)
        {
            if (talentsView == null)
            {
                talentsView = new TalentsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(talentsView);
        }

        private void NavigateToEquipment(object sender, RoutedEventArgs e)
        {
            if (equipmentView == null)
            {
                equipmentView = new EquipmentView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(equipmentView);
        }

        private void NavigateToSkills(object sender, RoutedEventArgs e)
        {
            if (skillsView == null)
            {
                skillsView = new SkillsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(skillsView);
        }

        private void NavigateToWoundsAndFatePoints(object sender, RoutedEventArgs e)
        {
            if (woundsAndFatePointsView == null)
            {
                woundsAndFatePointsView = new WoundsAndFatePointsView(this);
            }

            TabMenuContent.Children.Clear();
            TabMenuContent.Children.Add(woundsAndFatePointsView);
        }

        private void ShowSaveDialog(object sender, RoutedEventArgs e)
        {
            var view = new SaveDialog { DataContext = new SaveDialogViewModel() };

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) => 
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool) args.Parameter;
                    if (resp)
                    {
                        CurrentCharacterCreationData.Instance.Name = (view.DataContext as SaveDialogViewModel).Name;
                        SaveCharacter();
                    }
                }
            }));
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
            else if (baseViewModel is AptitudesViewModel)
            {
                if ((baseViewModel as AptitudesViewModel).Valid)
                {
                    if ((baseViewModel as AptitudesViewModel).HasDuplicates)
                    {
                        var view = new ApptitudesPickerDialog { DataContext = new ApptitudesPickerViewModel(baseViewModel as AptitudesViewModel) };

                        DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
                        {
                            if (args.Parameter is bool)
                            {
                                var resp = (bool)args.Parameter;
                                if (resp)
                                {
                                    (baseViewModel as AptitudesViewModel).ChangeDuplicatedApptitudes((view.DataContext as ApptitudesPickerViewModel).Aptitudes.Cast<AptitudeViewModel>().ToList());
                                }
                            }
                        }));
                    }
                    else
                    {
                        NavigateToTalentsTab.IsEnabled = true;
                        NavigateToTalentsTab.IsChecked = true;
                        (baseViewModel as AptitudesViewModel).SaveAptitudes();
                        NavigateToTalents(this, null);
                    }
                }
            }
            else if (baseViewModel is TalentsViewModel)
            {
                if ((baseViewModel as TalentsViewModel).Valid)
                {
                    NavigateToEquipmentTab.IsEnabled = true;
                    NavigateToEquipmentTab.IsChecked = true;
                    (baseViewModel as TalentsViewModel).SaveTalentsAndTraits();
                    NavigateToEquipment(this, null);
                }
            }
            else if (baseViewModel is EquipmentViewModel)
            {
                if ((baseViewModel as EquipmentViewModel).Valid)
                {
                    NavigateToSkillsTab.IsEnabled = true;
                    NavigateToSkillsTab.IsChecked = true;
                    (baseViewModel as EquipmentViewModel).SaveItems();
                    NavigateToSkills(this, null);
                }
            }
            else if (baseViewModel is SkillsViewModel)
            {
                if ((baseViewModel as SkillsViewModel).Valid)
                {
                    NavigateToWoundsAndFatePointsTab.IsEnabled = true;
                    NavigateToWoundsAndFatePointsTab.IsChecked = true;
                    (baseViewModel as SkillsViewModel).SaveSkills();
                    NavigateToWoundsAndFatePoints(this, null);
                }
            }
            else if (baseViewModel is WoundsAndFatePointsViewModel)
            {
                if ((baseViewModel as WoundsAndFatePointsViewModel).Valid)
                {
                    NavigateToWoundsAndFatePointsTab.IsEnabled = true;
                    NavigateToWoundsAndFatePointsTab.IsChecked = true;
                    (baseViewModel as WoundsAndFatePointsViewModel).Save();
                    ShowSaveDialog(this, null);
                }
            }
        }

        private void SaveCharacter()
        {
            var character =  _fileAccessService.SaveCharacter();
            CurrentCharacterData.Instance.Character = character;
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.UnblockCharacterManagement();
            parentWindow.MoveToCharacter();
        }
    }
}
