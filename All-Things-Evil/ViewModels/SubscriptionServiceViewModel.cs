using All_Things_Evil.Controllers;
using All_Things_Evil.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Things_Evil.ViewModels
{
    public class SubscriptionServiceViewModel : ISubscriptionServiceViewModel
    {
        private ICreditCardValidator creditCardInformationValidator;
        private ICreditCardService creditCardController;
        public SubscriptionServiceViewModel(ICreditCardValidator creditCardInformationValidator, ICreditCardService creditCardController)
        {
            this.creditCardInformationValidator = creditCardInformationValidator;
            this.creditCardController = creditCardController;
        }
        public bool ValidCreditCardInformation(string creditCardNumber, string cvv, string expirationDate)
        {
            bool validCreditCradNumber = creditCardInformationValidator.ValidCreditCardNumber(creditCardNumber);
            bool validExpirationDate = creditCardInformationValidator.ValidExpirationDate(expirationDate);
            bool validCVV = creditCardInformationValidator.ValidCVV(cvv);
            return validCreditCradNumber && validExpirationDate && validCVV;
        }
        public bool SaveCreditCardApi(string holderName, string cardNumber, string cvv, string expirationDate)
        {
            if (ValidCreditCardInformation(cardNumber, cvv, expirationDate))
            {
                creditCardController.SaveCard(holderName, cardNumber, expirationDate, cvv);
                return true;
            }
            return false;
        }

    }
}
