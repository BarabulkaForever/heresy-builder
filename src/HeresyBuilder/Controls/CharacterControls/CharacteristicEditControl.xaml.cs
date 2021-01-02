using HeresyBuilder.Helpers;
using HeresyBuilder.ViewModels.CharacterViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HeresyBuilder.Controls.CharacterControls
{
    /// <summary>
    /// Interaction logic for CharacteristicEditControl.xaml
    /// </summary>
    public partial class CharacteristicEditControl : UserControl
    {
        public CharacteristicEditControl()
        {
            InitializeComponent();

            CharacteristicNameChanged += new CharacteristicNameChangeHandler((object sender) =>
            {
                this.CharacteristicNameLabel.Content = this.CharacteristicName + " ";
                LoadCharacteristicPrise();
            });

            CharacteristicValueChanged += new CharacteristicValueChangeHandler((object sender) =>
            {
                this.CharacteristicValueLabel.Content = this.CharacteristicValue.ToString();
                LoadCharacteristicPrise();
            });

            CharacteristicLevelChanged += new CharacteristicLevelChangeHandler((object sender) =>
            {
                this.IsLvlOneCheckBox.IsChecked = this.IsLvlOne;
                this.IsLvlTwoCheckBox.IsChecked = this.IsLvlTwo;
                this.IsLvlThreeCheckBox.IsChecked = this.IsLvlThree;
                this.IsLvlFourCheckBox.IsChecked = this.IsLvlFour;
                this.IsLvlFiveCheckBox.IsChecked = this.IsLvlFive;

                if (this.IsLvlFour && !this.IsLvlFive)
                {
                    this.IsLvlFiveCheckBox.IsEnabled = true;
                }
                else
                {
                    this.IsLvlFiveCheckBox.IsEnabled = false;
                }

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
                LoadCharacteristicPrise();
            });
        }

        public static readonly DependencyProperty CharacteristicNameProperty =
            DependencyProperty.Register("CharacteristicName", typeof(string), typeof(CharacteristicEditControl), new PropertyMetadata(OnCharacteristicNameChanged));

        public string CharacteristicName
        {
            get { return (string)GetValue(CharacteristicNameProperty); }
            set
            {
                SetValue(CharacteristicNameProperty, value);
                CharacteristicNameChanged(this);
            }
        }

        static void OnCharacteristicNameChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            CharacteristicEditControl c = sender as CharacteristicEditControl;
            if (c.CharacteristicNameChanged != null)
                c.CharacteristicNameChanged(sender);
        }

        public delegate void CharacteristicNameChangeHandler(object sender);
        public CharacteristicNameChangeHandler CharacteristicNameChanged;


        public static readonly DependencyProperty CharacteristicValueProperty =
            DependencyProperty.Register("CharacteristicValue", typeof(int), typeof(CharacteristicEditControl), new PropertyMetadata(OnCharacteristicValueChanged));

        public int CharacteristicValue
        {
            get { return (int)GetValue(CharacteristicValueProperty); }
            set
            {
                SetValue(CharacteristicValueProperty, value);
                CharacteristicValueChanged(this);
            }
        }

        static void OnCharacteristicValueChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            CharacteristicEditControl c = sender as CharacteristicEditControl;
            if (c.CharacteristicValueChanged != null)
                c.CharacteristicValueChanged(sender);
        }

        public delegate void CharacteristicValueChangeHandler(object sender);
        public CharacteristicValueChangeHandler CharacteristicValueChanged;

        public static readonly DependencyProperty CharacteristicLevelProperty =
            DependencyProperty.Register("CharacteristicLevel", typeof(int), typeof(CharacteristicEditControl), new PropertyMetadata(OnCharacteristicLevelChanged));

        static void OnCharacteristicLevelChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            CharacteristicEditControl c = sender as CharacteristicEditControl;
            if (c.CharacteristicLevelChanged != null)
                c.CharacteristicLevelChanged(sender);
        }

        public delegate void CharacteristicLevelChangeHandler(object sender);
        public CharacteristicLevelChangeHandler CharacteristicLevelChanged;


        public int CharacteristicLevel
        {
            get { return (int)GetValue(CharacteristicLevelProperty); }
            set
            {
                SetValue(CharacteristicLevelProperty, value);
                CharacteristicLevelChanged(this);
            }
        }

        public bool IsLvlOne
        {
            get { return CharacteristicLevel >= 1; }
        }

        public bool IsLvlTwo
        {
            get { return CharacteristicLevel >= 2; }
        }

        public bool IsLvlThree
        {
            get { return CharacteristicLevel >= 3; }
        }

        public bool IsLvlFour
        {
            get { return CharacteristicLevel >= 4; }
        }

        public bool IsLvlFive
        {
            get { return CharacteristicLevel >= 5; }
        }

        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsEnabled)
            {
                var vm = (DataContext as CharacteristicViewModel).Parrent;
                
                var price = int.Parse(SkillPrice.Content as string);
                if (vm.CanSpendXP(price))
                {
                    vm.SpendXP(price);
                    CharacteristicLevel += 1;
                    CharacteristicValue += 5;
                }
                else
                {
                    (sender as CheckBox).IsChecked = false;
                }
            }
        }

        private void LoadCharacteristicPrise()
        {
            CharacteristicViewModel vm = DataContext as CharacteristicViewModel;
            if (vm.CharacteristicType == Enums.Characteristic.Influence) 
            {
                SkillPrice.Content = "N/A";
            }
            else
            {
                var characteristicPrise = CharacteristicsHelper.GetPriceForCharacteristic(vm.CharacteristicType, (Enums.CharacteristicLevel)CharacteristicLevel);

                if (((Enums.CharacteristicLevel)CharacteristicLevel) == Enums.CharacteristicLevel.Expert)
                {
                    SkillPrice.Content = "N/A";
                }
                else
                {
                    SkillPrice.Content = characteristicPrise.Prise.ToString();
                }

                SkillPrice.Foreground = GetCharacteristicForeground(characteristicPrise.Aptitudes);
            }
        }

        private Brush GetCharacteristicForeground(Enums.ContainsAptitudes aptitudes)
        {
            if (aptitudes == Enums.ContainsAptitudes.None)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#990000"));
            }
            else if (aptitudes == Enums.ContainsAptitudes.One)
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#b37400"));
            }
            else
            {
                return Brushes.Green;
            }
        }
    }
}
