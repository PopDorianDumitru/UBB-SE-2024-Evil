using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using All_Things_Evil.Services;
using All_Things_Evil.Views.WindowFactory;
using Humanizer;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.ViewModels
{
    public class FightingGameViewModel : INotifyPropertyChanged, IFightingGameViewModel
    {
        private readonly IGameService _gameService;
        private IWindowFactory _windowFactory;
        private int _player1Health;
        private int _player2Health;
        private int _player1Damage;
        private int _player1Block;
        private int _player1Energy;
        private int _player2Energy;

        public IWindowFactory GetWindowFactory()
        {
            return  _windowFactory;
        }

        public int Player1Health
        {
            get => _player1Health;
            set
            {
                _player1Health = value;
                OnPropertyChanged();
            }
        }

        public int Player2Health
        {
            get => _player2Health;
            set
            {
                _player2Health = value;
                OnPropertyChanged();
            }
        }

        public int Player1Damage
        {
            get => _player1Damage;
            set
            {
                _player1Damage = value;
                OnPropertyChanged();
            }
        }

        public int Player1Block
        {
            get => _player1Block;
            set
            {
                _player1Block = value;
                OnPropertyChanged();
            }
        }

        public int Player1Energy
        {
            get => _player1Energy;
            set
            {
                _player1Energy = value;
                OnPropertyChanged();
            }
        }

        public int Player2Energy
        {
            get => _player2Energy;
            set
            {
                _player2Energy = value;
                OnPropertyChanged();
            }
        }

        public ICommand DoMoveCommand { get; }
        public ICommand SaveGameCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FightingGameViewModel(IGameService gameService, IWindowFactory windowFactory)
        {
            _gameService = gameService;
            DoMoveCommand = new RelayCommand(DoMove, CanDoMove);
            SaveGameCommand = new RelayCommand(SaveGame);
            Player1Health = gameService.Game.PlayerHealthAtStartOfLevel;
            Player2Health = gameService.Game.Enemy.Health;
            Player1Energy = gameService.Game.Player.Energy;
            Player2Energy = gameService.Game.Enemy.MaxEnergy;
            _windowFactory = windowFactory;
            _gameService.StartNewGame("Test7");

        }

        private void DoMove()
        {
            try
            {
                var result = _gameService.DoMove(Player1Damage, Player1Block);

                Player2Health = _gameService.Game.Enemy.Health;
                Player1Health = _gameService.Game.Player.Health;
                if (result == UBB_SE_2024_Evil.Models.Spartacus.Result.WIN)
                {
                    
                    OnDisplayWinWindow();
                    _gameService.MoveToNextLevel();
                    Player1Health = _gameService.Game.PlayerHealthAtStartOfLevel;
                    Player2Health = _gameService.Game.Enemy.Health;
                    Player1Energy = _gameService.Game.Player.Energy;
                    Player2Energy = _gameService.Game.Enemy.MaxEnergy;
                }
                else if (result == UBB_SE_2024_Evil.Models.Spartacus.Result.LOSE)
                {
                   OnDisplayLoseWindow();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SaveGame()
        {
            _gameService.SaveGame();
        }

        private bool CanDoMove()
        {
            if (Player1Damage + Player1Block > Player1Energy)
            {
                return false;
            }
            if (Player1Damage < 0 || Player1Block < 0)
            {
                return false;
            }
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnDisplayWinWindow()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayWinWindow"));
        }

        protected virtual void OnDisplayLoseWindow()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayLoseWindow"));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
