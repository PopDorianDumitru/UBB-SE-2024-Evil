using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.Repos
{
    public interface IGameProxyRepository
    {
        Task<List<GameSave>> GetGameSaves(int userId);
        Task<GameSave> LoadSave(string id);
        Task<GameSave> NewSave(string runName);
        void SaveGame(GameSave gameSave);
    }
}