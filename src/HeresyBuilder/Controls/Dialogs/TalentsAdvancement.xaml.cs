﻿using HeresyBuilder.ViewModels.DialogViewMoldels;
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
    /// Interaction logic for TalentsAdvancement.xaml
    /// </summary>
    public partial class TalentsAdvancement : UserControl
    {
        private TalentsAdvancementViewModel viewModel;

        public TalentsAdvancement()
        {
            InitializeComponent();

            DataContext = viewModel = new TalentsAdvancementViewModel();
        }
    }
}
