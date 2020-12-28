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
    /// Interaction logic for SkillViewControl.xaml
    /// </summary>
    public partial class SkillViewControl : UserControl
    {
        public SkillViewControl()
        {
            InitializeComponent();
            SkillNameChanged += new SkillNameChangeHandler((object sender) =>
            {
                this.SkillNameLabel.Content = this.SkillName;
            });
            SkillLevelChanged += new SkillLevelChangeHandler((object sender) =>
            {
                this.IsLvlOneCheckBox.IsChecked = this.IsLvlOne;
                this.IsLvlTwoCheckBox.IsChecked = this.IsLvlTwo;
                this.IsLvlThreeCheckBox.IsChecked = this.IsLvlThree;
                this.IsLvlFourCheckBox.IsChecked = this.IsLvlFour;
            });
        }

        public static readonly DependencyProperty SkillNameProperty =
            DependencyProperty.Register("SkillName", typeof(string), typeof(SkillViewControl), new PropertyMetadata(OnSkillNameChanged));

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
            SkillViewControl c = sender as SkillViewControl;
            if (c.SkillNameChanged != null)
                c.SkillNameChanged(sender);
        }

        public delegate void SkillNameChangeHandler(object sender);
        public SkillNameChangeHandler SkillNameChanged;


        public static readonly DependencyProperty SkillLevelProperty =
            DependencyProperty.Register("SkillLevel", typeof(int), typeof(SkillViewControl), new PropertyMetadata(OnSkillLevelChanged));

        static void OnSkillLevelChanged(DependencyObject sender,
        DependencyPropertyChangedEventArgs args)
        {
            SkillViewControl c = sender as SkillViewControl;
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
    }
}
