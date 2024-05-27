using All_Things_Evil.ViewModels;
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
    /// Interaction logic for SubscriptionServiceView.xaml
    /// </summary>
    public partial class SubscriptionServiceView : UserControl
    {
        private string creditCardHolder = string.Empty;
        private string creditCardNumber = string.Empty;
        private string expirationDate = string.Empty;
        private string cVV = string.Empty;
        private bool validCreditCradNumber = false;
        private bool validExpirationDate = false;
        private bool validCVV = false;
        private ISubscriptionServiceViewModel subscriptionServiceViewModel;
        public SubscriptionServiceView(ISubscriptionServiceViewModel viewModel)
        {
            InitializeComponent();
            subscriptionServiceViewModel = viewModel;
        }
        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            creditCardHolder = NameTextBox.Text.Trim();
            creditCardNumber = CardNumberTextBox.Text.Trim();
            expirationDate = ExpirationDateTextBox.Text.Trim();
            cVV = CVVTextBox.Text.Trim();
            if(subscriptionServiceViewModel.ValidCreditCardInformation(creditCardNumber, cVV, expirationDate))
            {
                var result = MessageBox.Show("ok");
                subscriptionServiceViewModel.SaveCreditCardApi(creditCardHolder, creditCardNumber, cVV, expirationDate);
            }
            //if ((bool)this.DataContext.GetType().GetMethod("ValidCreditCardInformation").Invoke(this.DataContext, new object[] { creditCardNumber, cVV, expirationDate }) == true)
            //{
            //    var result = MessageBox.Show("ok");
            //    Console.WriteLine("[+] SUCCESSFULLY VALIDATED DATA. PREPARING TO COMMIT TO DATABASE");
            //    this.DataContext.GetType().GetMethod("SaveCreditCardApi").Invoke(this.DataContext, new object[] { creditCardHolder, creditCardNumber, cVV, expirationDate });
            //}
        }
        private void PayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            PayButton.Background = new BrushConverter().ConvertFrom("#757fe0") as Brush;
            PayButton.Cursor = Cursors.Hand;
        }

        private void PayButton_MouseLeave(object sender, MouseEventArgs e)
        {
            PayButton.Background = Brushes.Black;
        }

        private void NameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "Name on card")
            {
                NameTextBox.Text = string.Empty;
                NameTextBox.BorderBrush = new BrushConverter().ConvertFrom("#828282") as Brush;
            }
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == string.Empty)
            {
                NameTextBox.Text = "Name on card";
                NameTextBox.BorderBrush = Brushes.Red;
            }
        }

        private void CardNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CardNumberTextBox.Text == "- - - -   - - - -   - - - -   - - - -")
            {
                CardNumberTextBox.Text = string.Empty;
                CardNumberTextBox.BorderBrush = new BrushConverter().ConvertFrom("#828282") as Brush;
            }
        }

        private void CardNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CardNumberTextBox.Text == string.Empty)
            {
                CardNumberTextBox.Text = "- - - -   - - - -   - - - -   - - - -";
                CardNumberTextBox.BorderBrush = Brushes.Red;
            }
        }

        private void ExpirationDateTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ExpirationDateTextBox.Text == "MM/YY")
            {
                ExpirationDateTextBox.Text = string.Empty;
                ExpirationDateTextBox.BorderBrush = new BrushConverter().ConvertFrom("#828282") as Brush;
            }
        }

        private void ExpirationDateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ExpirationDateTextBox.Text == string.Empty)
            {
                ExpirationDateTextBox.Text = "MM/YY";
                ExpirationDateTextBox.BorderBrush = Brushes.Red;
            }
        }

        private void CVVTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CVVTextBox.Text == "- - -")
            {
                CVVTextBox.Text = string.Empty;
                CVVTextBox.BorderBrush = new BrushConverter().ConvertFrom("#828282") as Brush;
            }
        }

        private void CVVTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CVVTextBox.Text == string.Empty)
            {
                CVVTextBox.Text = "- - -";
                CVVTextBox.BorderBrush = Brushes.Red;
            }
        }
    }
}
