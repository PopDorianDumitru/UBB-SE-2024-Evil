using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using All_Things_Evil.Validators;
using All_Things_Evil.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using NuGet.Configuration;
using UBB_SE_2024_Evil.Controllers;

namespace All_Things_Evil.Views.WindowFactory
{
    public class WindowFactory : IWindowFactory
    {
        public IServiceProvider ServiceProvider;

        public WindowFactory(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public SubscriptionServiceView CreateSubscriptionWindow()
        {
            var subscriptionViewModel = ServiceProvider.GetRequiredService<ISubscriptionServiceViewModel>();
            return new SubscriptionServiceView(subscriptionViewModel);
        }

        public ScamBotsView CreateScamBotsWindow()
        {
            var scamBotsViewModel = ServiceProvider.GetRequiredService<IScamBotsViewModel>();
            return new ScamBotsView(scamBotsViewModel);
        }

        public SweetStealingView CreateSweetStealingView()
        {
            var sweetStealingViewModel = ServiceProvider.GetRequiredService<ISweetStealingViewModel>();
            return new SweetStealingView(sweetStealingViewModel);
        }

       public FightingGameView CreateFightingGameWindow()
        {
            var fightingGameViewModel = ServiceProvider.GetRequiredService<IFightingGameViewModel>();
            return new FightingGameView(fightingGameViewModel);
        }
        public FightingGameWinView CreateFightingGameWinWindow()
        {
            return new FightingGameWinView();
        }

        public FightingGameLoseView CreateFightingGameLoseWindow()
        {
            return new FightingGameLoseView();
        }
    }
}
