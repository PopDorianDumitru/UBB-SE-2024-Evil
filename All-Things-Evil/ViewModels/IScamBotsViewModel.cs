namespace All_Things_Evil.ViewModels
{
    public interface IScamBotsViewModel
    {
        bool SaveCreditCardApi(string holderName, string cardNumber, string cvv, string expirationDate);
        bool ValidCreditCardInformation(string creditCardNumber, string cvv, string expirationDate);
    }
}