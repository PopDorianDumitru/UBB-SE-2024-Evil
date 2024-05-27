namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class Player
    {
        public int Health { get; set; }
        public int Block { get; set; }
        public int Energy { get; set; }

        public Player(int health, int maxEnergy)
        {
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
