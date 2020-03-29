using System;
using System.Text;
using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character.Combat
{
    public class AttackableObject : InteractableObject, IAmAttackable
    {
        public override bool isInteractable { get; } = true;
        public bool isAttackable { get; } = true;

        private IDamaged[] _damagedComponents;
        
        private void Awake()
        {
            base.Awake();
            _damagedComponents = GetComponents<IDamaged>();
        }

        public void Attacked(Character attacker, Attack attack)
        {
            foreach (var t in _damagedComponents)
            {
                t.OnReceiveDamage(attacker, attack);
            }
        }

        public override void InteractWith(Character interacter)
        {
            print($"{interacter.name} can not currently attack {name}");
        }
    }
}