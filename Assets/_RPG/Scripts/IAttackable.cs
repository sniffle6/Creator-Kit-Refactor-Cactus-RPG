using _RPG.Scripts.MonoBehaviours.Character;
using _RPG.Scripts.MonoBehaviours.Character.Combat;
using UnityEngine;

namespace _RPG.Scripts
{
    public interface IAmAttackable
    {
        bool isAttackable { get; }
        void Attacked(Character attacker, Attack attack);
    }
}
