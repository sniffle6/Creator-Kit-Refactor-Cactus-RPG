using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character.Combat
{
    public class DamagedChangeHealth : MonoBehaviour, IDamaged
    {
        private CharacterStats _stats;

        private void Awake()
        {
            _stats = GetComponent<CharacterStats>();
        }

        public void OnReceiveDamage(Character attacker, Attack attack)
        {
            var (damage, critical) = attack;
            if (_stats)
                _stats.TakeDamage(critical ? damage * 2 : damage);
        }
    }
}