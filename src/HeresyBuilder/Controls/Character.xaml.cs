using HeresyBuilder.Controls.Dialogs;
using HeresyBuilder.Singleton;
using HeresyBuilder.ViewModels.CharacterViewModels;
using HeresyBuilder.ViewModels.DialogViewMoldels;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

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
            // LoadSkills();
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

        private void ShowCharacteristicsAdvansment(object sender, RoutedEventArgs e)
        {
            var view = new CharacteristicAdvancement();

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool)args.Parameter;
                    if (resp)
                    {
                        var newCharacterData = (view.DataContext as CharacteristicAdvancementViewModel);

                        CurrentCharacterData.Instance.Character.Characteristics = newCharacterData.Character.Characteristics;

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
