using HeresyBuilder.Controls.CharacterControls;
using HeresyBuilder.Controls.Dialogs;
using HeresyBuilder.Singleton;
using HeresyBuilder.ViewModels.CharacterViewModels;
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
    /// Interaction logic for Character.xaml
    /// </summary>
    public partial class Character : UserControl
    {
        CharacterViewModel viewModel;
        public Character()
        {
            InitializeComponent();
            DataContext = viewModel = new CharacterViewModel();
            LoadSkills();
            LoadTallents();
        }

        private void ShowSkillsAdvansment(object sender, RoutedEventArgs e)
        {
            var view = new SkillsAdvancement();

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool)args.Parameter;
                    if (resp)
                    {
                        var newCharacterData = (view.DataContext as SkillsAdvancementViewModel);

                        CurrentCharacterData.Instance.Character.Skills = newCharacterData.Character.Skills;

                        DataContext = null;
                        DataContext = viewModel;
                        viewModel.SpendXP(newCharacterData.SpendedXP);
                        LoadSkills();
                    }
                }
            }));
        }
        private void ShowTalentsAdvansment(object sender, RoutedEventArgs e)
        {
            var view = new TalentsAdvancement();

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool)args.Parameter;
                    if (resp)
                    {
                        // TODO save talents
                        var newCharacterData = (view.DataContext as TalentsAdvancementViewModel);

                        CurrentCharacterData.Instance.Character.Talents = newCharacterData.Character.Talents;

                        DataContext = null;
                        DataContext = viewModel;
                        viewModel.SpendXP(newCharacterData.SpendedXP);
                        LoadTallents();
                    }
                }
            }));
        }

        private void AddXP(object sender, RoutedEventArgs e)
        {
            var view = new AddXPDialog();

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool)args.Parameter;
                    if (resp)
                    {
                        int newXp = 0;
                        int.TryParse(view.NewXP.Text, out newXp);
                        viewModel.AddXP(newXp);
                    }
                }
            }));
        }

        private void LoadSkills()
        {
            LinguisticsStackPanel.Children.Clear();
            foreach (var skill in viewModel.Linguistics)
            {
                LinguisticsStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            TradeStackPanel.Children.Clear();
            foreach (var skill in viewModel.Trade)
            {
                TradeStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            CommonLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.CommonLore)
            {
                CommonLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            ScholasticLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.ScholasticLore)
            {
                ScholasticLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            ForbiddenLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.ForbiddenLore)
            {
                ForbiddenLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

        }

        private void LoadTallents()
        {
            TalentsStackPanel.Children.Clear();
            foreach (var talant in viewModel.Talents)
            {
                TalentsStackPanel.Children.Add(new Label
                {
                    FontSize = 14,
                    Content = talant,
                });
            }
        }
    }
}
