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
            this.DataContext = this;
        }

        public static readonly DependencyProperty SkillNameProperty =
            DependencyProperty.Register("SkillName", typeof(string), typeof(SkillViewControl), new UIPropertyMetadata(""));

        public string SkillName
        {
            get { return (string)GetValue(SkillNameProperty); }
            set { SetValue(SkillNameProperty, value); }
        }

        public static readonly DependencyProperty SkillLevelProperty =
            DependencyProperty.Register("SkillLevel", typeof(int), typeof(SkillViewControl), new UIPropertyMetadata(0));

        public int SkillLevel
        {
            get { return (int)GetValue(SkillLevelProperty); }
            set { SetValue(SkillLevelProperty, value); }
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
