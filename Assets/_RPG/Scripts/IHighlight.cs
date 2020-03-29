using _RPG.Scripts.MonoBehaviours;

namespace _RPG.Scripts
{
    public interface IHighlight
    {
        HighlightableObject highlighted { get; }
        void CheckForHighlight();
    }
}