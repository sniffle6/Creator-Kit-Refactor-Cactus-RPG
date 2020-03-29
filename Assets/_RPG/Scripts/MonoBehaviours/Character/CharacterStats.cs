using System;
using _RPG.Scripts.Scriptable_Objects;
using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] private StatObject baseStats;
        [SerializeField] private StatSystem stats;
        public StatSystem Stats => stats;

        private void Awake()
        {
            stats = new StatSystem(this, baseStats);
        }

        public void TakeDamage(int value)
        {
            stats.AdjustHealth(-value);
        }
    }
}
