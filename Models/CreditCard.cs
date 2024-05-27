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
        { }
    }
}
