using All_Things_Evil.Views;

namespace All_Things_Evil.ViewModels
{
    public interface ISweetStealingViewModel
    {
        ScamBotsView CreateScamBotsWindow();
        SubscriptionServiceView CreateSubscriptionWindow();
        FightingGameView CreateFightingGameWindow();
        SaveSelectGameView CreateSaveSelectGameWindow();
    }
}