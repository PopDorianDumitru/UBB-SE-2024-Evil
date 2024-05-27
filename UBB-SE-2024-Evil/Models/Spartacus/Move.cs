namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class Move
    {
        public int Damage { get; set; }
        public int Block { get; set; }
        public int EnergyCost
        {
            get
            {
                return Damage + Block;
            }
        }

        public Move(int damage, int block)
        {
            Damage = damage;
            Block = block;
        }
    }
}
