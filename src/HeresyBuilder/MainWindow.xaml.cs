using HeresyBuilder.Controls;
using HeresyBuilder.Singleton;
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

namespace HeresyBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListViewMenu.SelectedIndex = 0;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            if (index == 0)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new Start());
            }
            else if (index == 1) 
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new Build());
            }
            else if (index == 2)
            {
                if (CurrentCharacterData.Instance.Character != null)
                {
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Character());
                }
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        public void MoveToCharacterCreation()
        {
            ListViewMenu.SelectedIndex = 1;
        }

        public void MoveToCharacter()
        {
            ListViewMenu.SelectedIndex = 2;
        }
        
        public void UnblockCharacterManagement()
        {
            BuildMenuItem.Focusable = false;
            CharacterMenuItem.Focusable = true;
        }
    }
}
