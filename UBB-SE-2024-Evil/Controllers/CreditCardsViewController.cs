using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UBB_SE_2024_Evil.Controllers
{
    [Authorize]
    public class CreditCardsViewController : Controller
    {
        public IActionResult X()
        {
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }
    }
}
