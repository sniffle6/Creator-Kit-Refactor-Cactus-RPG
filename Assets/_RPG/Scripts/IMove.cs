using UnityEngine;

namespace _RPG.Scripts
{
    public interface IMove
    {
        void InitializeMove(Vector3 position);
        void StopMove();

        void FacePosition(Vector3 position);
    }
}