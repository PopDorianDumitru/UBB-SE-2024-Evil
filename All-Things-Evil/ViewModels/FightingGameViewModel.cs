using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using All_Things_Evil.Services;

namespace All_Things_Evil.ViewModels
{
    public class FightingGameViewModel : INotifyPropertyChanged, IFightingGameViewModel
    {
        private readonly IGameService _gameService;
        private int _player1Health;
        private int _player2Health;
        private int _player1Damage;
        private int _player1Block;

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

        public ICommand DoMoveCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FightingGameViewModel(IGameService gameService)
        {
            _gameService = gameService;
            DoMoveCommand = new RelayCommand(DoMove);
            Player1Health = 100;
            Player2Health = 100;
        }

        private void DoMove()
        {
            var result = _gameService.DoMove(Player1Damage, Player1Block);
            Player2Health -= Player1Damage;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
