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
        private readonly IGameService gameService;
        private IWindowFactory windowFactory;
        private int player1Health;
        private int player2Health;
        private int player1Damage;
        private int player1Block;
        private int player1Energy;
        private int player2Energy;
        private string enemyName;
        private int player1MaxHealth;
        private int player2MaxHealth;

        public IWindowFactory GetWindowFactory()
        {
            return windowFactory;
        }

        public int Player1Health
        {
            get => player1Health;
            set
            {
                player1Health = value;
                OnPropertyChanged();
            }
        }

        public int Player2Health
        {
            get => player2Health;
            set
            {
                player2Health = value;
                OnPropertyChanged();
            }
        }

        public int Player1Damage
        {
            get => player1Damage;
            set
            {
                player1Damage = value;
                OnPropertyChanged();
            }
        }

        public int Player1Block
        {
            get => player1Block;
            set
            {
                player1Block = value;
                OnPropertyChanged();
            }
        }

        public int Player1Energy
        {
            get => player1Energy;
            set
            {
                player1Energy = value;
                OnPropertyChanged();
            }
        }

        public int Player2Energy
        {
            get => player2Energy;
            set
            {
                player2Energy = value;
                OnPropertyChanged();
            }
        }

        public string EnemyName
        {
            get => enemyName;
            set
            {
                enemyName = value;
                OnPropertyChanged();
            }
        }

        public int Player1MaxHealth
        {
            get => player1MaxHealth;
            set
            {
                player1MaxHealth = value;
                OnPropertyChanged();
            }
        }

        public int Player2MaxHealth
        {
            get => player2MaxHealth;
            set
            {
                player2MaxHealth = value;
                OnPropertyChanged();
            }
        }

        public ICommand DoMoveCommand { get; }
        public ICommand SaveGameCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FightingGameViewModel(IGameService gameService, IWindowFactory windowFactory)
        {
            this.gameService = gameService;
            DoMoveCommand = new RelayCommand(DoMove, CanDoMove);
            SaveGameCommand = new RelayCommand(SaveGame);
            Player1Health = gameService.Game.PlayerHealthAtStartOfLevel;
            Player2Health = gameService.Game.Enemy.Health;
            Player1Energy = gameService.Game.Player.Energy;
            Player2Energy = gameService.Game.Enemy.MaxEnergy;
            EnemyName = gameService.Game.Enemy.Name.Humanize();
            Player1MaxHealth = gameService.Game.Player.MaxHealth;
            Player2MaxHealth = gameService.Game.Enemy.MaxHealth;
            this.windowFactory = windowFactory;
            this.gameService.StartNewGame(new Random().Next().ToString());
        }
        private void DoMove()
        {
            try
            {
                var result = gameService.DoMove(Player1Damage, Player1Block);

                Player2Health = gameService.Game.Enemy.Health;
                Player1Health = gameService.Game.Player.Health;
                if (enemyName != gameService.Game.Enemy.Name)
                {
                    Player1Health = gameService.Game.PlayerHealthAtStartOfLevel;
                    Player2Health = gameService.Game.Enemy.Health;
                    Player1Energy = gameService.Game.Player.Energy;
                    Player2Energy = gameService.Game.Enemy.MaxEnergy;
                    Player1MaxHealth = gameService.Game.Player.MaxHealth;
                    Player2MaxHealth = gameService.Game.Enemy.MaxHealth;
                    enemyName = gameService.Game.Enemy.Name;
                }
                if (result == UBB_SE_2024_Evil.Models.Spartacus.Result.WIN)
                {
                    OnDisplayWinWindow();
                    gameService.ResetGame();
                    Player1Health = gameService.Game.PlayerHealthAtStartOfLevel;
                    Player2Health = gameService.Game.Enemy.Health;
                    Player1Energy = gameService.Game.Player.Energy;
                    Player2Energy = gameService.Game.Enemy.MaxEnergy;
                    Player1MaxHealth = gameService.Game.Player.MaxHealth;
                    Player2MaxHealth = gameService.Game.Enemy.MaxHealth;
                    enemyName = gameService.Game.Enemy.Name;
                }
                else if (result == UBB_SE_2024_Evil.Models.Spartacus.Result.LOSE)
                {
                    OnDisplayLoseWindow();
                    gameService.ResetGame();
                    Player1Health = gameService.Game.PlayerHealthAtStartOfLevel;
                    Player2Health = gameService.Game.Enemy.Health;
                    Player1Energy = gameService.Game.Player.Energy;
                    Player2Energy = gameService.Game.Enemy.MaxEnergy;
                    Player1MaxHealth = gameService.Game.Player.MaxHealth;
                    Player2MaxHealth = gameService.Game.Enemy.MaxHealth;
                    enemyName = gameService.Game.Enemy.Name;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SaveGame()
        {
            gameService.SaveGame();
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
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
