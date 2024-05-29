using All_Things_Evil.Services;
using All_Things_Evil.Views;
using All_Things_Evil.Views.WindowFactory;
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
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.ViewModels
{
    public class SaveSelectGameViewModel : INotifyPropertyChanged, ISaveSelectGameViewModel
    {
        private readonly IGameService _gameService;
        private readonly IWindowFactory _windowFactory;
        private GameSave _selectedGameSave;
        private string _newRunName;

        public SaveSelectGameViewModel(IGameService gameService, IWindowFactory windowFactory)
        {
            _gameService = gameService;
            _windowFactory = windowFactory;
            GameSaves = new ObservableCollection<GameSave>();
            LoadGameSavesCommand = new RelayCommand(LoadGameSaves);
            StartNewGameCommand = new RelayCommand(StartNewGame);
            ContinueGameCommand = new RelayCommand(ContinueGame);
            //LoadGameSaves();
        }

        public ObservableCollection<GameSave> GameSaves { get; }

        public GameSave SelectedGameSave
        {
            get => _selectedGameSave;
            set
            {
                if (_selectedGameSave != value)
                {
                    _selectedGameSave = value;
                    OnPropertyChanged();
                    //LoadSelectedGame();
                }
            }
        }

        public string NewRunName
        {
            get => _newRunName;
            set
            {
                if (_newRunName != value)
                {
                    _newRunName = value;
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

        private void LoadGameSaves()
        {
            int userId = 1; // Assume this is retrieved from the user context
            _gameService.GetGameSaves(userId);
            GameSaves.Clear();
            foreach (var save in _gameService.GameSaves)
            {
                GameSaves.Add(save);
            }
        }

        private void StartNewGame()
        {
            if (string.IsNullOrEmpty(_newRunName))
            {
                MessageBox.Show("Please enter a name for the new run.", "Missing Run Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //string newRunName = "New Run " + (GameSaves.Count + 1); // Example run name
            _gameService.StartNewGame(NewRunName);
            //LoadGameSaves();
        }

        private void LoadSelectedGame()
        {
            if (SelectedGameSave != null)
            {
                _gameService.LoadGame(SelectedGameSave);
            }
        }
        private void ContinueGame()
        {
            if(SelectedGameSave == null)
            {
                MessageBox.Show("Please select a game save to continue.", "No Game Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _gameService.SaveGame();
        }

        public FightingGameView CreateFightingGameWindow()
        {
            return _windowFactory.CreateFightingGameWindow();
        }
    }
}
