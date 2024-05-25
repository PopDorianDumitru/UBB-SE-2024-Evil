namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class Enemy
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public int Damage { get; set; }

        public int Block { get; set; }

        public int Heal { get; set; }

        public Enemy(string name, int health, int damage, int block)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Block = block;
        }

        public int DoAttack()
        {
            Random random = new Random();
            int randomDamage = random.Next(0, 5);

            if (random.Next(0, 2) == 0)
            {
                randomDamage = -randomDamage;
            }

            return Damage + randomDamage;
        }

        public void DoBlock()
        {
            Random random = new Random();
            int randomBlock = random.Next(0, 5);

            if (random.Next(0, 2) == 0)
            {
                randomBlock = -randomBlock;
            }

            Armor = Block + randomBlock;
        }

        public void DoHeal()
        {
            Random random = new Random();
            int randomHeal = random.Next(0, 5);

            Health += Heal + randomHeal;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
