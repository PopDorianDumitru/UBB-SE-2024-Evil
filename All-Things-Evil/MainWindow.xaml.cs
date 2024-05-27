﻿using All_Things_Evil.Views.WindowFactory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace All_Things_Evil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWindowFactory windowFactory;

        public MainWindow(IWindowFactory windowFactory)
        {
            this.windowFactory = windowFactory;
            var sweetStealingView = windowFactory.CreateSweetStealingView();
            InitializeComponent();
            MainGrid.Children.Add(sweetStealingView);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}