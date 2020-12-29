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
                LinguisticsStackPanel.Children.Remove(view);
                viewModel.SetPropertyChanged(nameof(viewModel.Linguistics));
            };

            view.Clear.Click += (s, arg) =>
            {
                LinguisticsStackPanel.Children.Remove(view);
            };

            LinguisticsStackPanel.Children.Add(view);
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
                viewModel.SetPropertyChanged(nameof(viewModel.Trade));
                TradeStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                TradeStackPanel.Children.Remove(view);
            };

            TradeStackPanel.Children.Add(view);
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
                viewModel.SetPropertyChanged(nameof(viewModel.CommonLore));
                CommonLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                CommonLoreStackPanel.Children.Remove(view);
            };

            CommonLoreStackPanel.Children.Add(view);
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
                viewModel.SetPropertyChanged(nameof(viewModel.ScholasticLore));
                ScholasticLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                ScholasticLoreStackPanel.Children.Remove(view);
            };

            ScholasticLoreStackPanel.Children.Add(view);
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
                viewModel.SetPropertyChanged(nameof(viewModel.ForbiddenLore));
                ForbiddenLoreStackPanel.Children.Remove(view);
            };

            view.Clear.Click += (s, arg) =>
            {
                ForbiddenLoreStackPanel.Children.Remove(view);
            };

            ForbiddenLoreStackPanel.Children.Add(view);
        }

    }
}
