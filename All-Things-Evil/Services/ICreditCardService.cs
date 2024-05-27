namespace All_Things_Evil.Controllers
{
    internal interface ICreditCardService
    {
        void SaveCard(string holderName, string creditCardNumber, string expirationDate, string cvv);
    }
}