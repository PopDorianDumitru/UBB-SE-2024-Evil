using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using All_Things_Evil.Services;
using All_Things_Evil.Views;
using All_Things_Evil.Views.WindowFactory;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.ViewModels
{
    public class SaveSelectGameViewModel : INotifyPropertyChanged, ISaveSelectGameViewModel
    {
        private readonly IGameService gameService;
        private readonly IWindowFactory windowFactory;
        private GameSave selectedGameSave;
        private string newRunName;

        public SaveSelectGameViewModel(IGameService gameService, IWindowFactory windowFactory)
        {
            this.gameService = gameService;
            this.gameService.GetGameSaves();
            this.windowFactory = windowFactory;
            GameSaves = new ObservableCollection<GameSave>();
            LoadGameSavesCommand = new RelayCommand(LoadGameSaves);
            StartNewGameCommand = new RelayCommand(StartNewGame);
            ContinueGameCommand = new RelayCommand(ContinueGame);
            LoadGameSaves();
        }

        public ObservableCollection<GameSave> GameSaves { get; }

        public GameSave SelectedGameSave
        {
            get => selectedGameSave;
            set
            {
                if (selectedGameSave != value)
                {
                    selectedGameSave = value;
                    OnPropertyChanged();
                    // LoadSelectedGame();
                }
            }
        }

        public string NewRunName
        {
            get => newRunName;
            set
            {
                if (newRunName != value)
                {
                    newRunName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoadGameSavesCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand ContinueGameCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadGameSaves()
        {
            int userId = 1; // Assume this is retrieved from the user context
            await gameService.GetGameSaves();
            GameSaves.Clear();
            if (gameService.GameSaves == null)
            {
                return;
            }
            foreach (var save in gameService.GameSaves)
            {
                GameSaves.Add(save);
            }
        }

        private void StartNewGame()
        {
            if (string.IsNullOrEmpty(newRunName))
            {
                MessageBox.Show("Please enter a name for the new run.", "Missing Run Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // string newRunName = "New Run " + (GameSaves.Count + 1); // Example run name
            gameService.StartNewGame(NewRunName);
            // LoadGameSaves();
        }

        private void LoadSelectedGame()
        {
            if (SelectedGameSave != null)
            {
                gameService.LoadGame(SelectedGameSave);
            }
        }
        private void ContinueGame()
        {
            if (SelectedGameSave == null)
            {
                MessageBox.Show("Please select a game save to continue.", "No Game Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            gameService.SaveGame();
        }

        public FightingGameView CreateFightingGameWindow(string selectedSave)
        {
            return windowFactory.CreateFightingGameWindow();
        }

        public object CreateFightingGameWindow(int selectedIndex)
        {
            gameService.LoadGame(GameSaves[selectedIndex]);
            return windowFactory.CreateFightingGameWindow();
        }

        public object CreateFightingGameWindowNewSave(string saveName)
        {
            // gameService.StartNewGame(saveName);
            return windowFactory.CreateFightingGameWindow();
        }
    }
}
