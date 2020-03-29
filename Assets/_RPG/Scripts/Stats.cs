using System;

namespace _RPG.Scripts
{
    [Serializable]
    public class Stats
    {
        public int maxHealth;
        public int strength;
        public int defense;
        public int agility;

        public void Copy(Stats other)
        {
            maxHealth = other.maxHealth;
            strength = other.strength;
            defense = other.defense;
            agility = other.agility;
        }
    }
}