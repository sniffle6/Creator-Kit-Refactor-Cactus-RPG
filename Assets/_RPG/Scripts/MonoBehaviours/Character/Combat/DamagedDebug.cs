using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character.Combat
{
    public class DamagedDebug : MonoBehaviour, IDamaged
    {
        public void OnReceiveDamage(Character attacker, Attack attack)
        {
            var (damage, critical) = attack;
            
            print(string.Concat( $"{name} was attacked by {attacker.name} ",
                $"for {(critical ? damage * 2 : damage).ToString("n0")}. ",
                $"Hit was critical: {critical.ToString()}"));
        }
    }
}