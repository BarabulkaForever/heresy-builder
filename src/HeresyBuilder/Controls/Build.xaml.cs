﻿using HeresyBuilder.Controls.BuildControls;
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
        private TalentsView talentsView; 
        private EquipmentView equipmentView; 
        private SkillsView skillsView; 
        private WoundsAndFatePointsView woundsAndFatePointsView; 

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
                    NavigateToTalentsTab.IsEnabled = true;
                    NavigateToTalentsTab.IsChecked = true;
                    (baseViewModel as AptitudesViewModel).SaveAptitudes();
                    NavigateToTalents(this, null);
                }
            }
            else if (baseViewModel is TalentsViewModel)
            {
                if ((baseViewModel as TalentsViewModel).Valid)
                {
                    NavigateToEquipmentTab.IsEnabled = true;
                    NavigateToEquipmentTab.IsChecked = true;
                    (baseViewModel as TalentsViewModel).SaveTalents();
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
        }
    }
}
