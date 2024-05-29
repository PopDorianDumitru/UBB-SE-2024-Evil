using UBB_SE_2024_Evil.Models;

namespace UBB_SE_2024_Evil.Validators
{
    public class CreditCardValidator
    {
        public static void Validate(CreditCard creditCard)
        {
            List<string> errors = new List<string>();

            if (creditCard == null)
            {
                throw new ArgumentNullException(nameof(creditCard));
            }

            if (string.IsNullOrWhiteSpace(creditCard.CreditCardHolder))
            {
                errors.Add("Credit card holder is required.");
            }

            if (string.IsNullOrWhiteSpace(creditCard.CreditCardNumber))
            {
                errors.Add("Credit card number is required.");
            }
            else if (creditCard.CreditCardNumber.Length != 16)
            {
                errors.Add("Credit card number must be 16 digits long.");
            }

            if (string.IsNullOrWhiteSpace(creditCard.ExpirationDate))
            {
                errors.Add("Expiration date is required.");
            }
            else if (!DateTime.TryParse(creditCard.ExpirationDate, out _))
            {
                errors.Add("Invalid expiration date.");
            }

            if (string.IsNullOrWhiteSpace(creditCard.Cvv))
            {
                errors.Add("CVV is required.");
            }
            else if (creditCard.Cvv.Length != 3)
            {
                errors.Add("CVV must be 3 digits long.");
            }

            if (errors.Any())
            {
                string message = string.Join(Environment.NewLine, errors);
                throw new Exception(message);
            }
        }
    }
}
