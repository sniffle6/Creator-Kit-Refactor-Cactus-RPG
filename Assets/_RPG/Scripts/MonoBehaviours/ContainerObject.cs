using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours
{
    public class ContainerObject : InteractableObject
    {
        public override bool isInteractable { get; } = true;
        
        public override void InteractWith(Character.Character interacter)
        {
            print($"{interacter.name} is checking container inside of {name}");
        }
    }
}
