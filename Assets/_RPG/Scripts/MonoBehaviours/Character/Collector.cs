using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class Collector: MonoBehaviour, ICanInteract
    {
        public void Interact(Character interacter, InteractableObject interactingWith)
        {
            if (interactingWith is ContainerObject containerObject)
            {
                containerObject.InteractWith(interacter);
            }
        }
    }
}