using System;
using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours
{
    public abstract class InteractableObject : HighlightableObject
    {
        public abstract bool isInteractable { get; }
        public new Collider collider;

        protected void Awake()
        {
            collider = GetComponent<Collider>();
        }

        public abstract void InteractWith(Character.Character interacter);
    }
}
