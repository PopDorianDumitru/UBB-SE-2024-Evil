namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class Enemy
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Block { get; set; }
        public int MaxEnergy { get; set; }
        public List<Move> Moves { get; set; }
        public int CurrentMoveIndex { get; set; }

        public Enemy(string name, int maxHealth, int health, int maxEnergy, List<Move> moves)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = health;
            Block = 0;
            MaxEnergy = maxEnergy;
            Moves = moves;
            CurrentMoveIndex = 0;
        }

        public Move GetCurrentMove()
        {
            Move enemyMove = Moves[CurrentMoveIndex];
            NextMove();
            return enemyMove;
        }

        private void NextMove()
        {
            CurrentMoveIndex++;
            if (CurrentMoveIndex >= Moves.Count)
            {
                CurrentMoveIndex = 0;
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= Block > 0 ? Math.Max(0, damage - Block) : damage;
        }
    }
}
