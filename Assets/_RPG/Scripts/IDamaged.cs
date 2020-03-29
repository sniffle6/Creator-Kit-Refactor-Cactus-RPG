using _RPG.Scripts.MonoBehaviours.Character;

namespace _RPG.Scripts
{
    public interface IDamaged
    {
        void OnReceiveDamage(Character attacker, Attack attack);
    }
}
