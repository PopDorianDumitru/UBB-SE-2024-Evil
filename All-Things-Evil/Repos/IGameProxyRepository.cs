using UBB_SE_2024_Evil.Models.Spartacus;

namespace All_Things_Evil.Repos
{
    public interface IGameProxyRepository
    {
        Task<List<GameSave>> GetGameSaves();
        Task<GameSave> LoadSave(int id);
        Task<GameSave> NewSave(GameSave runName);
        void SaveGame(GameSave gameSave);
    }
}