using System.Text.Json.Serialization;

namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class GameSave
    {
        private static readonly int STARTING_HEALTH = 100;
        private static readonly int STARTING_ENERGY = 30;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("playerHealth")]
        public int PlayerHealth { get; set; }

        [JsonPropertyName("playerEnergy")]
        public int PlayerEnergy { get; set; }

        public GameSave()
        {
        }

        public GameSave(string runName)
        {
            Name = runName;
            Level = 0;
            PlayerHealth = STARTING_HEALTH;
            PlayerEnergy = 30;
        }

        public GameSave(int id, int level, string name, int playerHealth, int playerEnergy)
        {
            Id = id;
            Level = level;
            Name = name;
            PlayerHealth = playerHealth;
            PlayerEnergy = playerEnergy;
        }

        public GameSave(int id)
        {
            Id = id;
        }
    }
}
