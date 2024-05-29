using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Things_Evil.Views;
using All_Things_Evil.Views.WindowFactory;

namespace All_Things_Evil.ViewModels
{
    public class SweetStealingViewModel : ISweetStealingViewModel
    {
        private IWindowFactory windowFactory;
        public SweetStealingViewModel(IWindowFactory windowFactory)
        {
            this.windowFactory = windowFactory;
        }
        public SubscriptionServiceView CreateSubscriptionWindow()
        {
            return windowFactory.CreateSubscriptionWindow();
        }
        public ScamBotsView CreateScamBotsWindow()
        {
            return windowFactory.CreateScamBotsWindow();
        }

        public FightingGameView CreateFightingGameWindow()
        {
            return windowFactory.CreateFightingGameWindow();
        }
    }
}
