namespace All_Things_Evil.Controllers
{
    public interface ICreditCardService
    {
        void SaveCard(string holderName, string creditCardNumber, string expirationDate, string cvv);
    }
}