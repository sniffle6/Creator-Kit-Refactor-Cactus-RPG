namespace _RPG.Scripts
{
    public class Attack
    {
        public readonly int Damage;
        public readonly bool Critical;

        public Attack(int damage, bool critical)
        {
            Damage = damage;
            Critical = critical;
        }

        public void Deconstruct(out int damage, out bool critical)
        {
            damage = Damage;
            critical = Critical;
        }
    }
}