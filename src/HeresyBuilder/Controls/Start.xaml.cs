using HeresyBuilder.Controls.Dialogs;
using HeresyBuilder.Services;
using HeresyBuilder.Singleton;
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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : UserControl
    {
        public Start()
        {
            InitializeComponent();
        }

        private void CreateNewCharacter(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow) Window.GetWindow(this);
            parentWindow.MoveToCharacterCreation();
        }

        private void LoadExistingCharacter(object sender, RoutedEventArgs e)
        {
            var view = new LoadCharacterDialog { DataContext = new LoadCharacterDialogViewModel() };

            DialogHost.Show(view, "RootDialog", new DialogClosingEventHandler((s, args) =>
            {
                if (args.Parameter is bool)
                {
                    var resp = (bool)args.Parameter;
                    if (resp)
                    {
                        var service = new FileAccessService();
                        var characterName = (view.DataContext as LoadCharacterDialogViewModel).SellectedCharacter;
                        var character = service.LoadCharacter(characterName);
                        CurrentCharacterData.Instance.Character = character;
                        MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
                        parentWindow.UnblockCharacterManagement();
                        parentWindow.MoveToCharacter();
                    }
                }
            }));
        }
    }
}
