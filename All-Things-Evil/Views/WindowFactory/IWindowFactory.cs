namespace All_Things_Evil.Views.WindowFactory
{
    public interface IWindowFactory
    {
        ScamBotsView CreateScamBotsWindow();
        SubscriptionServiceView CreateSubscriptionWindow();
        SweetStealingView CreateSweetStealingView();
        FightingGameView CreateFightingGameWindow();
        FightingGameWinView CreateFightingGameWinWindow();
        FightingGameLoseView CreateFightingGameLoseWindow();
    }
}