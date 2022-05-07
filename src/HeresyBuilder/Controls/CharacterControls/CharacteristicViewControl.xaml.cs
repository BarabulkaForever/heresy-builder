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
    /// Interaction logic for CharacteristicViewControl.xaml
    /// </summary>
    public partial class CharacteristicViewControl : UserControl
    {
        public CharacteristicViewControl()
        {
            InitializeComponent();

            CharacteristicNameChanged += new CharacteristicNameChangeHandler((object sender) =>
            {
                this.CharacteristicNameLabel.Content = this.CharacteristicName + " ";
            });

            CharacteristicValueChanged += new CharacteristicValueChangeHandler((object sender) =>
            {
                this.CharacteristicValueLabel.Content = this.CharacteristicValue.ToString();
            });

            CharacteristicLevelChanged += new CharacteristicLevelChangeHandler((object sender) =>
            {
                this.IsLvlOneCheckBox.IsChecked = this.IsLvlOne;
                this.IsLvlTwoCheckBox.IsChecked = this.IsLvlTwo;
                this.IsLvlThreeCheckBox.IsChecked = this.IsLvlThree;
                this.IsLvlFourCheckBox.IsChecked = this.IsLvlFour;
                this.IsLvlFiveCheckBox.IsChecked = this.IsLvlFive;
            });
        }

        public static readonly DependencyProperty CharacteristicNameProperty =
            DependencyProperty.Register("CharacteristicName", typeof(string), typeof(CharacteristicViewControl), new PropertyMetadata(OnCharacteristicNameChanged));

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
            CharacteristicViewControl c = sender as CharacteristicViewControl;
            if (c.CharacteristicNameChanged != null)
                c.CharacteristicNameChanged(sender);
        }

        public delegate void CharacteristicNameChangeHandler(object sender);
        public CharacteristicNameChangeHandler CharacteristicNameChanged;


        public static readonly DependencyProperty CharacteristicValueProperty =
            DependencyProperty.Register("CharacteristicValue", typeof(int), typeof(CharacteristicViewControl), new PropertyMetadata(OnCharacteristicValueChanged));

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
            CharacteristicViewControl c = sender as CharacteristicViewControl;
            if (c.CharacteristicValueChanged != null)
                c.CharacteristicValueChanged(sender);
        }

        public delegate void CharacteristicValueChangeHandler(object sender);
        public CharacteristicValueChangeHandler CharacteristicValueChanged;

        public static readonly DependencyProperty CharacteristicLevelProperty =
            DependencyProperty.Register("CharacteristicLevel", typeof(int), typeof(CharacteristicViewControl), new PropertyMetadata(OnCharacteristicLevelChanged));

        static void OnCharacteristicLevelChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            CharacteristicViewControl c = sender as CharacteristicViewControl;
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
    }
}
