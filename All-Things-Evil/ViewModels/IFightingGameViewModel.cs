using System.ComponentModel;
using System.Windows.Input;
using All_Things_Evil.Views.WindowFactory;

namespace All_Things_Evil.ViewModels
{
    public interface IFightingGameViewModel
    {
        ICommand DoMoveCommand { get; }
        int Player1Block { get; set; }
        int Player1Damage { get; set; }
        int Player1Energy { get; set; }
        int Player1Health { get; set; }
        int Player2Energy { get; set; }
        IWindowFactory GetWindowFactory();
        string EnemyName { get; set; }
        int Player1MaxHealth { get; set; }
        int Player2MaxHealth { get; set; }
        int Player2Health { get; set; }
        ICommand SaveGameCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}