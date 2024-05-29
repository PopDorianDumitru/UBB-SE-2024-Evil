using Newtonsoft.Json;

namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public enum Result
    {
        WIN,
        LOSE,
        CONTINUE
    }

    public class Game
    {
        private static int STARTING_ENERGY = 30;
        private static int MAX_ENERGY_INCREASE = 5;
        private static int STARTING_HEALTH = 100;
        private static string ENEMY_FILE = "./Models/Spartacus/enemies.json";

        public int GameSaveId { get; set; } = -1;
        public Player Player { get; set; }
        public int PlayerHealthAtStartOfLevel { get; set; }
        public Enemy Enemy { get; set; }
        public string RunName { get; set; }
        public int Level { get; set; }
        public List<Enemy> Enemies { get; set; }

        public Game(GameSave gameSave)
        {
            GameSaveId = gameSave.Id;
            Enemies = LoadEnemies();
            RunName = gameSave.Name;
            Level = gameSave.Level;
            Player = new Player(STARTING_HEALTH, gameSave.PlayerHealth, gameSave.PlayerEnergy);
            PlayerHealthAtStartOfLevel = gameSave.PlayerHealth;
            Enemy = Enemies[Level];
        }

        public bool NextLevel()
        {
            Level++;
            if (Level >= Enemies.Count)
            {
                return true;
            }
            Player.Energy = STARTING_ENERGY + MAX_ENERGY_INCREASE;
            PlayerHealthAtStartOfLevel = Player.Health;
            Enemy = Enemies[Level];
            return false;
        }

        public Result DoMove(Move playerMove)
        {
            Move enemyMove = Enemy.GetCurrentMove();

            Enemy.Block = enemyMove.Block;
            Player.Block = playerMove.Block;

            Player.TakeDamage(enemyMove.Damage);
            Enemy.TakeDamage(playerMove.Damage);

            Enemy.Block = 0;
            Player.Block = 0;

            if (Player.Health <= 0)
            {
                return Result.LOSE;
            }
            if (Enemy.Health <= 0)
            {
                bool isGameOver = NextLevel();
                if (isGameOver)
                {
                    return Result.WIN;
                }
            }
            return Result.CONTINUE;
        }

        public GameSave GetGameSave()
        {
            return new GameSave
            {
                Id = GameSaveId,
                Name = RunName,
                Level = Level,
                PlayerHealth = PlayerHealthAtStartOfLevel,
                PlayerEnergy = Player.Energy
            };
        }

        public void Reset()
        {
            Level = 0;
            Player = new Player(STARTING_HEALTH, STARTING_HEALTH, STARTING_ENERGY);
            PlayerHealthAtStartOfLevel = STARTING_HEALTH;
            Enemy = Enemies[Level];
        }

        private static List<Enemy> LoadEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            using (StreamReader r = new StreamReader(ENEMY_FILE))
            {
                string json = r.ReadToEnd();
                enemies = JsonConvert.DeserializeObject<List<Enemy>>(json);
            }
            return enemies;
        }
    }
}
