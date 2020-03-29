using UnityEngine;

namespace _RPG.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Stat Object", menuName = "RPG/Stat")]
    public class StatObject : ScriptableObject
    {
        public Stats definition;
    }
}
