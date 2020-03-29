using UnityEngine;

namespace _RPG.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(menuName = "RPG/Database/VFX", fileName = "Vfx Database", order = 1)]
    public class VfxDatabase : ScriptableObject
    {
        [System.Serializable]
        public class  VfxDbEntry
        {
            public string name;
            public GameObject prefab;
            public int poolSize = 6;
        }

        public VfxDbEntry[] entries;
    }
}