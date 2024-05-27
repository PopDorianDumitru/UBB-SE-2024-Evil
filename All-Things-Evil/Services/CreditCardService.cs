using All_Things_Evil.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UBB_SE_2024_Evil.Models;

namespace All_Things_Evil.Controllers
{
    internal class CreditCardService : ICreditCardService
    {
        ICreditCardProxyRepository creditCardProxyRepo;
        public CreditCardService()
        {
        }
        public CreditCardService(ICreditCardProxyRepository repo)
        {
            creditCardProxyRepo = repo;
        }
        public async void SaveCard(string holderName, string creditCardNumber, string expirationDate, string cvv)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int id = random.Next();

            CreditCard card = new CreditCard(id, holderName, creditCardNumber, expirationDate, cvv);
            creditCardProxyRepo.SaveCreditCard(card);
        }

    }
}
