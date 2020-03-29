using _RPG.Scripts.MonoBehaviours;
using _RPG.Scripts.MonoBehaviours.Character;

namespace _RPG.Scripts
{
    public interface ICanInteract
    {
        void Interact(Character interacter, InteractableObject interactingWith);
    }
}