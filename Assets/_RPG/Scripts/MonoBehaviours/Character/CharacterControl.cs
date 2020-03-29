using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class CharacterControl : MonoBehaviour
    {
        [SerializeField] private Collider targetCollider;
        [SerializeField] private InteractableObject targetObject;
        
        private Transform _transform;
        private IMove _move;
        
        private ICanInteract[] _interacts;


        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _transform = transform;
            _move = GetComponent<IMove>();
            _interacts = GetComponents<ICanInteract>();
        }


        private void Update()
        {
            if (targetObject)
            {
                CheckInteractableRange();
            }
        }


        public void InteractWith(InteractableObject obj)
        {
            if (!obj.isInteractable)
                return;
            TargetObject(obj);
            _move.InitializeMove(obj.transform.position);
        }


        private void TargetObject(InteractableObject obj) =>
            (targetCollider, targetObject) = (obj.collider, obj);


        public void DeTargetObject()
        {
            if (targetObject)
                (targetCollider, targetObject) = (null, null);
        }


        private void CheckInteractableRange()
        {
            var position = _transform.position;
            var distance = targetCollider.ClosestPointOnBounds(position) - position;

            if (!(distance.sqrMagnitude < 1.65f * 1.65f))
                return;

            _move.StopMove();
            _move.FacePosition(targetCollider.ClosestPointOnBounds(position));
            foreach (var interaction in _interacts)
            {
                interaction.Interact(_character, targetObject);
            }
            DeTargetObject();
        }
    }
}