using HeresyBuilder.Enums;
using HeresyBuilder.Helpers;
using HeresyBuilder.ViewModels.CharacterViewModels;
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

namespace HeresyBuilder.Controls.CharacterControls
{
    /// <summary>
    /// Interaction logic for SkillEditControl.xaml
    /// </summary>
    public partial class SkillEditControl : UserControl
    {
        public SkillEditControl()
        {
            InitializeComponent();

            SkillNameChanged += new SkillNameChangeHandler((object sender) =>
            {
                this.SkillNameLabel.Content = this.SkillName;
                LoadSkillPrise();
            });

            SkillLevelChanged += new SkillLevelChangeHandler((object sender) =>
            {
                this.IsLvlOneCheckBox.IsChecked = this.IsLvlOne;
                this.IsLvlTwoCheckBox.IsChecked = this.IsLvlTwo;
                this.IsLvlThreeCheckBox.IsChecked = this.IsLvlThree;
                this.IsLvlFourCheckBox.IsChecked = this.IsLvlFour;

                if (this.IsLvlThree && !this.IsLvlFour)
                {
                    this.IsLvlFourCheckBox.IsEnabled = true;
                }
                else
                {
                    this.IsLvlFourCheckBox.IsEnabled = false;
                }

                if (this.IsLvlTwo && !this.IsLvlThree)
                {
                    this.IsLvlThreeCheckBox.IsEnabled = true;
                }
                else
                {
                    this.IsLvlThreeCheckBox.IsEnabled = false;
                }

                if (this.IsLvlOne && !this.IsLvlTwo)
                {
                    this.IsLvlTwoCheckBox.IsEnabled = true;
                }
                else
                {
                    this.IsLvlTwoCheckBox.IsEnabled = false;
                } 

                if (!this.IsLvlOne) 
                {
                    this.IsLvlOneCheckBox.IsEnabled = true;
                }
                else
                {
                    this.IsLvlOneCheckBox.IsEnabled = false;
                }

                LoadSkillPrise();
            });

            SpecialSkillsChanged += new SpecialSkillsChangeHandler((object sender) => {
                LoadSkillPrise();
            });
        }

        public static readonly DependencyProperty SkillNameProperty =
            DependencyProperty.Register("SkillName", typeof(string), typeof(SkillEditControl), new PropertyMetadata(OnSkillNameChanged));

        public string SkillName
        {
            get { return (string)GetValue(SkillNameProperty); }
            set 
            {
                SetValue(SkillNameProperty, value);
                SkillNameChanged(this);
            }
        }

        static void OnSkillNameChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            SkillEditControl c = sender as SkillEditControl;
            if (c.SkillNameChanged != null)
                c.SkillNameChanged(sender);
        }

        public delegate void SkillNameChangeHandler(object sender);
        public SkillNameChangeHandler SkillNameChanged;


        public static readonly DependencyProperty SkillLevelProperty =
            DependencyProperty.Register("SkillLevel", typeof(int), typeof(SkillEditControl), new PropertyMetadata(OnSkillLevelChanged));

        static void OnSkillLevelChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            SkillEditControl c = sender as SkillEditControl;
            if (c.SkillLevelChanged != null)
                c.SkillLevelChanged(sender);
        }

        public delegate void SkillLevelChangeHandler(object sender);
        public SkillLevelChangeHandler SkillLevelChanged;


        public int SkillLevel
        {
            get { return (int)GetValue(SkillLevelProperty); }
            set 
            {
                SetValue(SkillLevelProperty, value);
                SkillLevelChanged(this);
                if (DataContext is SkillInListViewModel)
                {
                    (DataContext as SkillInListViewModel).Level = value;
                }
            }
        }

        public static readonly DependencyProperty SpecialSkillsProperty =
            DependencyProperty.Register("SpecialSkills", typeof(string), typeof(SkillEditControl), new PropertyMetadata(OnSpecialSkillsChanged));

        static void OnSpecialSkillsChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            SkillEditControl c = sender as SkillEditControl;
            if (c.SpecialSkillsChanged != null)
                c.SpecialSkillsChanged(c);
        }

        public delegate void SpecialSkillsChangeHandler(object sender);
        public SpecialSkillsChangeHandler SpecialSkillsChanged;


        public string SpecialSkills
        {
            get { return (string)GetValue(SpecialSkillsProperty); }
            set 
            { 
                SetValue(SpecialSkillsProperty, value);
                SpecialSkillsChanged(this);
            }
        }

        public bool IsLvlOne
        {
            get { return SkillLevel >= 1; }
        }

        public bool IsLvlTwo
        {
            get { return SkillLevel >= 2; }
        }

        public bool IsLvlThree
        {
            get { return SkillLevel >= 3; }
        }

        public bool IsLvlFour
        {
            get { return SkillLevel >= 4; }
        }

        private void LoadSkillPrise()
        {
            if (!string.IsNullOrEmpty(SpecialSkills))
            {
                SkillHelper.SkillPrise skillPrise;
                
                if (SpecialSkills == "no")
                {
                    skillPrise = SkillHelper.GetPriceForSkill(SkillName, (Enums.SkillLevel) SkillLevel);
                }
                else
                {
                    skillPrise = SkillHelper.GetPriceForSkill(SpecialSkills, (Enums.SkillLevel) SkillLevel);
                }

                if (((Enums.SkillLevel)SkillLevel) == Enums.SkillLevel.Veteran)
                {
                    SkillPrice.Content = "N/A";
                }
                else
                {
                    SkillPrice.Content = skillPrise.Prise.ToString();
                }

                SkillPrice.Foreground = GetSkillForeground(skillPrise.Aptitudes);
            }
        }

        private Brush GetSkillForeground(ContainsAptitudes aptitudes)
        {
            if (aptitudes == ContainsAptitudes.None)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#990000"));
            }
            else if (aptitudes == ContainsAptitudes.One)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#b37400"));
            }
            else
            {
                return Brushes.Green;
            }
        }

        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsEnabled)
            {
                SkillsAdvancementViewModel vm;
                if (DataContext is SkillsAdvancementViewModel)
                {
                    vm = DataContext as SkillsAdvancementViewModel;
                }
                else
                {
                    vm = (DataContext as SkillInListViewModel).Parrent;
                }
                var price = int.Parse(SkillPrice.Content as string);
                if (vm.CanSpendXP(price))
                {
                    vm.SpendXP(price);
                    SkillLevel += 1;
                }
                else
                {
                    (sender as CheckBox).IsChecked = false;
                }
            }
        }
    }
}
