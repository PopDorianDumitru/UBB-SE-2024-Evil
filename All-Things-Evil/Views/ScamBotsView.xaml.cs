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
using All_Things_Evil.ViewModels;

namespace All_Things_Evil.Views
{
    /// <summary>
    /// Interaction logic for ScamBotsView.xaml
    /// </summary>
    public partial class ScamBotsView : UserControl
    {
        private IScamBotsViewModel scamBotsViewModel;
        public ScamBotsView()
        {
            InitializeComponent();
        }
        public ScamBotsView(IScamBotsViewModel viewModel)
        {
            InitializeComponent();
            scamBotsViewModel = viewModel;
        }
        private void TextNameChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBlockName.Text) && TextBlockName.Text.Length > 0)
            {
                TextBlockName.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockName.Visibility = Visibility.Visible;
            }
        }

        private void TextNameMD(object sender, RoutedEventArgs e)
        {
            TextBoxName.Focus();
        }

        // CreditNr
        private void TextCreditNrChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBlockCreditNr.Text) && TextBlockCreditNr.Text.Length > 0)
            {
                TextBlockCreditNr.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockCreditNr.Visibility = Visibility.Visible;
            }
        }

        private void TextCreditNrMD(object sender, RoutedEventArgs e)
        {
            TextBoxCreditNr.Focus();
        }

        // CVV
        private void TextCVVChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBlockCVV.Text) && TextBlockCVV.Text.Length > 0)
            {
                TextBlockCVV.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockCVV.Visibility = Visibility.Visible;
            }
        }

        private void TextCVVMD(object sender, RoutedEventArgs e)
        {
            TextBoxCVV.Focus();
        }

        // ExpYear
        private void TextExpYearChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBlockExpYear.Text) && TextBlockExpYear.Text.Length > 0)
            {
                TextBlockExpYear.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockExpYear.Visibility = Visibility.Visible;
            }
        }

        private void TextExpYearMD(object sender, RoutedEventArgs e)
        {
            TextBoxExpYear.Focus();
        }
        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string creditCardNumber = TextBoxCreditNr.Text;
            string cvv = TextBoxCVV.Text;
            string expirationDate = TextBoxExpYear.Text;
            try
            {
                scamBotsViewModel.ValidCreditCardInformation(creditCardNumber, cvv, expirationDate);
                scamBotsViewModel.SaveCreditCardApi(name, creditCardNumber, cvv, expirationDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred " + ex.Message);
                // MessageBox.Show("An error occurred: " + ex.Message);
            }
            // SoundPlayer sound = new SoundPlayer("../../../ScamBotsPhishingFrontend/vine-boom.wav");
            // sound.Play();
        }
    }
}
