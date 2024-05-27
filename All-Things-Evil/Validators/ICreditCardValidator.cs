namespace All_Things_Evil.Validators
{
    public interface ICreditCardValidator
    {
        bool ValidCreditCardNumber(string creditCardNumber);
        bool ValidCVV(string cvv);
        bool ValidExpirationDate(string expirationDate);
    }
}