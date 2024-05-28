using All_Things_Evil.Repos;
using Humanizer.Localisation.TimeToClockNotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.Services
{
    public class GameService : IGameService
    {
        private Game game;
        private IGameProxyRepository gameProxyRepository;
        private List<GameSave> gameSaves;
        public Game Game { get { return game; } }
        public List<GameSave> GameSaves { get { return gameSaves; } }

        public GameService() { }
        public GameService(IGameProxyRepository repo)
        {
            this.game = new Game(new GameSave("Test"));
            gameProxyRepository = repo;
        }
        public GameService(IGameProxyRepository repo, Game game)
        {
            this.game = game;
            this.gameProxyRepository = repo;
        }
        public async void StartNewGame(string runName)
        {
            Task<GameSave> gameSaveTask = gameProxyRepository.NewSave(runName);
            GameSave gameSave = await gameSaveTask;
            game = new Game(gameSave);
        }
        public void LoadGame(GameSave gameSave)
        {
            game = new Game(gameSave);
        }
        public async void LoadGame(string id)
        {
            Task<GameSave> gameSaveTask = gameProxyRepository.LoadSave(id);
            GameSave gameSave = await gameSaveTask;
            game = new Game(gameSave);
        }
        public async void SaveGame()
        {
            GameSave gameSave = game.GetGameSave();
            gameProxyRepository.SaveGame(gameSave);
        }
        public async void GetGameSaves(int userId)
        {
            Task<List<GameSave>> gameSavesTask = gameProxyRepository.GetGameSaves(userId);
            gameSaves = await gameSavesTask;
        }

        public bool MoveToNextLevel()
        {
            return game.NextLevel();
        }

        public Result DoMove(int damage, int block)
        {
            Move playerMove = new Move(damage, block);

            return game.DoMove(playerMove);

        }
        public GameSave GetGameSave()
        {
            return game.GetGameSave();
        }
        public void ResetGame()
        {
            game.Reset();
        }

    }
}
