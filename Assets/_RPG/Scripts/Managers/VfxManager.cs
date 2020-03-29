using System;
using System.Collections.Generic;
using _RPG.Scripts.Scriptable_Objects;
using UnityEngine;

namespace _RPG.Scripts.Managers
{
    public class VfxManager : MonoBehaviour
    {
        public class VfxInstance
        {
            public GameObject Effect;
            public int Index;
        }

        private static VfxManager instance { get; set; }
        public VfxDatabase database;

        private Queue<VfxInstance>[] _instances;

        private void Awake()
        {
            instance = this;
            Init();
        }

        private void Init()
        {
            _instances = new Queue<VfxInstance>[database.entries.Length];

            for (int i = 0; i < database.entries.Length; i++)
            {
                _instances[i] = new Queue<VfxInstance>();
                CreateNewInstances(i);
            }
        }

        private void CreateNewInstances(int index)
        {
            var entry = database.entries[index];

            for (var i = 0; i < entry.poolSize; i++)
            {
                var vfxInstance = new VfxInstance();
                var inst = Instantiate(entry.prefab);
                inst.gameObject.SetActive(false);

                vfxInstance.Effect = inst;
                vfxInstance.Index = index;
                
                _instances[index].Enqueue(vfxInstance);
            }
        }

        public static VfxInstance GetVfx(VfxType type)
        {
            var idx = (int)type;
            if (instance._instances[idx].Count == 0)
            {
                instance.CreateNewInstances(idx);
            }

            var inst = instance._instances[idx].Dequeue();
            instance._instances[idx].Enqueue(inst);
            
            inst.Effect.gameObject.SetActive(true);
            return inst;
        }

        public static VfxInstance PlayVfx(VfxType type, Vector3 position)
        {
            var i = GetVfx(type);
            i.Effect.gameObject.transform.position = position;

            return i;
        }
    }

    public enum VfxType
    {
        StepPuff
    }
}