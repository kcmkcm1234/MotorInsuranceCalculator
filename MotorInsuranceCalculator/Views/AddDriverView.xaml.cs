﻿using MotorInsuranceCalculator.ViewModels;
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

namespace MotorInsuranceCalculator.Views
{
    /// <summary>
    /// Interaction logic for AddDriverView.xaml
    /// </summary>
    public partial class AddDriverView : Window
    {
        public AddDriverView()
        {
            InitializeComponent();

            this.DataContext = new AddDriverViewModel();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
