﻿namespace UBB_SE_2024_Evil.Models.Spartacus
{
    public class GameSave
    {
        private static int STARTING_HEALTH = 100;
        private static int STARTING_ENERGY = 30;

        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerEnergy { get; set; }

        public GameSave()
        { }

        public GameSave(string runName)
        {
            Name = runName;
            Level = 0;
            PlayerHealth = STARTING_HEALTH;
            PlayerEnergy = 30;
        }
    }
}