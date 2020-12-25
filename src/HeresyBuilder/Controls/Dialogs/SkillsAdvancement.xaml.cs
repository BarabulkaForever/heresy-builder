using HeresyBuilder.Controls.CharacterControls;
using HeresyBuilder.ViewModels.DialogViewMoldels;
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

            foreach (var skill in viewModel.Linguistics)
            {
                LinguisticsStackPanel.Children.Add(new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Linguistics"
                });
            }

            foreach (var skill in viewModel.Trade)
            {
                TradeStackPanel.Children.Add(new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Trade"
                });
            }

            foreach (var skill in viewModel.CommonLore)
            {
                CommonLoreStackPanel.Children.Add(new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Common Lore"
                });
            }

            foreach (var skill in viewModel.ScholasticLore)
            {
                ScholasticLoreStackPanel.Children.Add(new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Scholastic Lore"
                });
            }

            foreach (var skill in viewModel.ForbiddenLore)
            {
                ForbiddenLoreStackPanel.Children.Add(new SkillEditControl
                {
                    SkillName = skill.Name,
                    SkillLevel = (int)skill.Level,
                    SpecialSkills = "Forbidden Lore"
                });
            }
        }
    }
}
