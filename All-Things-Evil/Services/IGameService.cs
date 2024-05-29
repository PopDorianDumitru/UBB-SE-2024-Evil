using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.Services
{
    public interface IGameService
    {
        Game Game { get; }
        List<GameSave> GameSaves { get; }

        Result DoMove(int damage, int block);
        GameSave GetGameSave();
        void GetGameSaves(int userId);
        void LoadGame(GameSave gameSave);
        void LoadGame(int id);
        bool MoveToNextLevel();
        void ResetGame();
        void SaveGame();
        void StartNewGame(string runName);
    }
}