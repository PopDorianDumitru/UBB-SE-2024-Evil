using All_Things_Evil.Views.WindowFactory;
using System.ComponentModel;
using System.Windows.Input;

namespace All_Things_Evil.ViewModels
{
    public interface IFightingGameViewModel
    {
        ICommand DoMoveCommand { get; }
        int Player1Block { get; set; }
        int Player1Damage { get; set; }
        int Player1Health { get; set; }
        int Player2Health { get; set; }
        int Player1Energy { get; set; }
        int Player2Energy { get; set; }
        IWindowFactory GetWindowFactory();


        event PropertyChangedEventHandler PropertyChanged;
    }
}