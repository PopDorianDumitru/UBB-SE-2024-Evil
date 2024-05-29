namespace All_Things_Evil.Views.WindowFactory
{
    public interface IWindowFactory
    {
        ScamBotsView CreateScamBotsWindow();
        SubscriptionServiceView CreateSubscriptionWindow();
        SweetStealingView CreateSweetStealingView();
        FightingGameView CreateFightingGameWindow();
        SaveSelectGameView CreateSaveSelectGameWindow();
        FightingGameWinView CreateFightingGameWinWindow();
        FightingGameLoseView CreateFightingGameLoseWindow();
    }
}