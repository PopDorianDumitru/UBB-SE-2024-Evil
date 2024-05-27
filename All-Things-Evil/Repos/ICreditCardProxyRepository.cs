using UBB_SE_2024_Evil.Models;

namespace All_Things_Evil.Repos
{
    internal interface ICreditCardProxyRepository
    {
        void SaveCreditCard(CreditCard card);
    }
}