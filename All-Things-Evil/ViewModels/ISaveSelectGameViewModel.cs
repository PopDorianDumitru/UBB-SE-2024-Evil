using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using All_Things_Evil.Views;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.ViewModels
{
    public interface ISaveSelectGameViewModel
    {
        ObservableCollection<GameSave> GameSaves { get; }
        GameSave SelectedGameSave { get; set; }
        string NewRunName { get; set; }
        ICommand LoadGameSavesCommand { get; }
        ICommand StartNewGameCommand { get; }
        ICommand ContinueGameCommand { get; }

        FightingGameView CreateFightingGameWindow(string runName);
        object CreateFightingGameWindow(int selectedIndex);
        object CreateFightingGameWindowNewSave(string text);
    }
}
