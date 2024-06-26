﻿using System;
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
using System.Windows.Shapes;
using All_Things_Evil.Views.WindowFactory;

namespace All_Things_Evil
{
    /// <summary>
    /// Interaction logic for SweetSpartacusPage.xaml
    /// </summary>
    public partial class SweetSpartacusPage : Window
    {
        private IWindowFactory windowFactory;

        public SweetSpartacusPage(IWindowFactory windowFactory)
        {
            this.windowFactory = windowFactory;
            InitializeComponent();
        }

        private void SweetStealingButton_Click(object sender, RoutedEventArgs eventArguments)
        {
            try
            {
                MainGrid.Children.Clear();
                var sweetStealingView = windowFactory.CreateSweetStealingView();
                MainGrid.Children.Add(sweetStealingView);
            }
            catch (System.Exception exception)
            {
            }
        }

        private void FightingGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainGrid.Children.Clear();
                var fightingGameWindow = windowFactory.CreateSaveSelectGameWindow();
                MainGrid.Children.Add(fightingGameWindow);
            }
            catch (System.Exception exception)
            {
            }
        }
    }
}
