using HeresyBuilder.Controls.CharacterControls;
using HeresyBuilder.ViewModels.CharacterViewModels;
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

            foreach(var skill in viewModel.Linguistics)
            {
                LinguisticsStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int) skill.Level,
                });
            }

            foreach (var skill in viewModel.Trade)
            {
                TradeStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            foreach (var skill in viewModel.CommonLore)
            {
                CommonLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            foreach (var skill in viewModel.ScholasticLore)
            {
                ScholasticLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

            foreach (var skill in viewModel.ForbiddenLore)
            {
                ForbiddenLoreStackPanel.Children.Add(new SkillViewControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                });
            }

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
