using All_Things_Evil.ViewModels;
using All_Things_Evil.Views.WindowFactory;
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

namespace All_Things_Evil.Views
{
    /// <summary>
    /// Interaction logic for SweetStealingView.xaml
    /// </summary>
    public partial class SweetStealingView : UserControl
    {
        ISweetStealingViewModel sweetStealingViewModel;
        public SweetStealingView(ISweetStealingViewModel viewModel)
        {
            InitializeComponent();
            sweetStealingViewModel = viewModel;
        }

        private void SubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var subscriptionWindow = sweetStealingViewModel.CreateSubscriptionWindow();
                MainContentControl.Content = subscriptionWindow;
            }
            catch (System.Exception exception)
            {
            }
        }

       

        private void ScamBotsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var scamBotsWindow = sweetStealingViewModel.CreateScamBotsWindow();
                MainContentControl.Content = scamBotsWindow;
            }
            catch (System.Exception exception)
            {
            }
        }
    }
}
