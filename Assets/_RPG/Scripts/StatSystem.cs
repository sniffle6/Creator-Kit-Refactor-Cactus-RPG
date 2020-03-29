using System;
using _RPG.Scripts.MonoBehaviours.Character;
using _RPG.Scripts.Scriptable_Objects;
using UnityEngine;

namespace _RPG.Scripts
{
    [System.Serializable]
    public class StatSystem
    {
        [SerializeField] private Stats stats;
        [SerializeField] private int currentHealth;
        private CharacterStats _owner;
        
        public Stats Stats => stats;
        public int CurrentHealth
        {
            get => currentHealth;
            private set => currentHealth = value;
        }

        public StatSystem(CharacterStats owner, StatObject baseStats)
        {
            _owner = owner;
            stats = new Stats();
            Stats.Copy(baseStats.definition);
            CurrentHealth = Stats.maxHealth;
        }


        public void AdjustHealth(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, Stats.maxHealth);
        }
    }
}