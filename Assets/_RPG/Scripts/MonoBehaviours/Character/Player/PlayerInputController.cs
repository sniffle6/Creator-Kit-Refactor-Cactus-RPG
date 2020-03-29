using Cinemachine;
using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        [SerializeField] private Character characterPlayingAs;
        private IMove _characterMover;
        private CharacterControl _characterController;

        [SerializeField] private HighlightableObject highlightedObject;
        [SerializeField] private InteractableObject objectSelected;

        private IHighlight _highlight;
        private readonly RaycastHit[] _raycastHitCache = new RaycastHit[16];
        private Vector3 _lastRaycastResult;
        private int _levelLayer;


        private void Awake()
        {
            _levelLayer = 1 << LayerMask.NameToLayer("Level");
            _lastRaycastResult = transform.position;

            _highlight = GetComponent<IHighlight>();
            _characterMover = characterPlayingAs.GetComponent<IMove>();
            _characterController = characterPlayingAs.GetComponent<CharacterControl>();
            mainCamera = Camera.main;
        }

        private void OnValidate()
        {
            _characterMover = characterPlayingAs.GetComponent<IMove>();
            _characterController = characterPlayingAs.GetComponent<CharacterControl>();
            virtualCamera.Follow = characterPlayingAs.transform.GetChild(1);
            virtualCamera.LookAt = characterPlayingAs.transform.GetChild(1);
        }

        private void Update()
        {
            _highlight.CheckForHighlight();
            highlightedObject = _highlight?.highlighted;

            if (!Input.GetMouseButton(0))
                return;

            if (highlightedObject is InteractableObject interactableObject)
            {
                objectSelected = interactableObject;
                _characterController.InteractWith(objectSelected);
                return;
            }
            objectSelected = null;
            _characterController.DeTargetObject();
            
            var screenRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            _characterMover.InitializeMove(ValidateMove(screenRay));
        }

        private Vector3 ValidateMove(Ray screenRay)
        {
            if (Physics.RaycastNonAlloc(screenRay, _raycastHitCache, 1000.0f, _levelLayer) <= 0)
                return _lastRaycastResult;

            var point = _raycastHitCache[0].point;

            return (Vector3.SqrMagnitude(point - _lastRaycastResult) > 1.0f) ? point : _lastRaycastResult;
        }
    }
}