using HeresyBuilder.Controls.CharacterControls;
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

namespace HeresyBuilder.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for SkillsAdvancement.xaml
    /// </summary>
    public partial class SkillsAdvancement : UserControl
    {
        SkillsAdvancementViewModel viewModel;
        public SkillsAdvancement()
        {
            InitializeComponent();

            DataContext = viewModel = new SkillsAdvancementViewModel();
            LoadSkills();
        }

        public void LoadSkills()
        {
            LoadLinguistics();

            LoadTrade();

            LoadCommonLore();

            LoadScholasticLore();

            LoadForbiddenLore();
        }

        private void AddLinguistics(object sender, RoutedEventArgs e)
        {
            var view = new AddSkillView();
            view.Done.Click += (s, arg) =>
            {
                viewModel.Character.Skills.Linguistics.Add(new Models.Skill
                {
                    Level = Enums.SkillLevel.UnKnown,
                    Name = view.SkillName.Text
                });
                LoadLinguistics();
                LinguisticsStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                LinguisticsStackPanel.Children.Remove(view);
            };

            LinguisticsStackPanel.Children.Add(view);
        }

        public void LoadLinguistics()
        {
            LinguisticsStackPanel.Children.Clear();
            foreach (var skill in viewModel.Linguistics)
            {
                var view = new SkillEditControl
                {
                    SkillName = skill.Name,
                    SpecialSkills = "Linguistics",
                    SkillLevel = (int)skill.Level
                };
                LinguisticsStackPanel.Children.Add(view);
                view.DataContext = skill;
            }
        }

        private void AddTrade(object sender, RoutedEventArgs e)
        {
            var view = new AddSkillView();
            view.Done.Click += (s, arg) =>
            {
                viewModel.Character.Skills.Trade.Add(new Models.Skill
                {
                    Level = Enums.SkillLevel.UnKnown,
                    Name = view.SkillName.Text
                });
                LoadTrade();
                TradeStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                TradeStackPanel.Children.Remove(view);
            };

            TradeStackPanel.Children.Add(view);
        }

        public void LoadTrade()
        {
            TradeStackPanel.Children.Clear();
            foreach (var skill in viewModel.Trade)
            {
                var view = new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Trade"
                };
                TradeStackPanel.Children.Add(view);
                view.DataContext = skill;
            }
        }

        private void AddCommonLore(object sender, RoutedEventArgs e)
        {
            var view = new AddSkillView();
            view.Done.Click += (s, arg) =>
            {
                viewModel.Character.Skills.CommonLore.Add(new Models.Skill
                {
                    Level = Enums.SkillLevel.UnKnown,
                    Name = view.SkillName.Text
                });
                LoadTrade();
                CommonLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                CommonLoreStackPanel.Children.Remove(view);
            };

            CommonLoreStackPanel.Children.Add(view);
        }

        public void LoadCommonLore()
        {
            CommonLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.CommonLore)
            {
                var view = new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Common Lore"
                };
                CommonLoreStackPanel.Children.Add(view);
                view.DataContext = skill;
            }
        }

        private void AddScholasticLore(object sender, RoutedEventArgs e)
        {
            var view = new AddSkillView();
            view.Done.Click += (s, arg) =>
            {
                viewModel.Character.Skills.ScholasticLore.Add(new Models.Skill
                {
                    Level = Enums.SkillLevel.UnKnown,
                    Name = view.SkillName.Text
                });
                LoadTrade();
                ScholasticLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                ScholasticLoreStackPanel.Children.Remove(view);
            };

            ScholasticLoreStackPanel.Children.Add(view);
        }

        public void LoadScholasticLore()
        {
            ScholasticLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.ScholasticLore)
            {
                var view = new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Scholastic Lore"
                };
                ScholasticLoreStackPanel.Children.Add(view);
                view.DataContext = skill;
            }
        }

        private void AddForbiddenLore(object sender, RoutedEventArgs e)
        {
            var view = new AddSkillView();
            view.Done.Click += (s, arg) =>
            {
                viewModel.Character.Skills.ForbiddenLore.Add(new Models.Skill
                {
                    Level = Enums.SkillLevel.UnKnown,
                    Name = view.SkillName.Text
                });
                LoadTrade();
                ForbiddenLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                ForbiddenLoreStackPanel.Children.Remove(view);
            };

            ForbiddenLoreStackPanel.Children.Add(view);
        }

        public void LoadForbiddenLore()
        {
            ForbiddenLoreStackPanel.Children.Clear();
            foreach (var skill in viewModel.ForbiddenLore)
            {
                var view = new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Forbidden Lore"
                };
                ForbiddenLoreStackPanel.Children.Add(view);
                view.DataContext = skill;
            }
        }
    }
}
