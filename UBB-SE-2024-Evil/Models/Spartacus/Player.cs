namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class Player
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Block { get; set; }
        public int Energy { get; set; }

        public Player(int maxHealth, int health, int maxEnergy)
        {
            MaxHealth = maxHealth;
            Health = health;
            Block = 0;
            Energy = maxEnergy;
        }

        public void TakeDamage(int damage)
        {
            Health -= Block > 0 ? Math.Max(0, damage - Block) : damage;
        }
    }
}
