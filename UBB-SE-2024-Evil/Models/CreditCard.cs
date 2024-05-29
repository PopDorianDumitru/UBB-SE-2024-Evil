namespace UBB_SE_2024_Evil.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CreditCardHolder { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }

        public CreditCard()
        {
        }

        public CreditCard(string creditCardHolder, string creditCardNumber, string expirationDate, string cvv)
        {
            CreditCardHolder = creditCardHolder;
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            Cvv = cvv;
        }
    }
}
