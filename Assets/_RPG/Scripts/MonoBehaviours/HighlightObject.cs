using UnityEngine;
using UnityEngine.EventSystems;

namespace _RPG.Scripts.MonoBehaviours
{
    public class HighlightObject : MonoBehaviour, IHighlight
    {
        public HighlightableObject highlighted { get; private set; }


        private Camera _camera;
        private readonly RaycastHit[] _raycastHitCache = new RaycastHit[8];
        private int _interactableLayer;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _interactableLayer = 1 << LayerMask.NameToLayer("Interactable");
        }
        
        
        public void CheckForHighlight()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                ObjectRaycasts(_camera.ScreenPointToRay(Input.mousePosition));
            }
        }

        public void ObjectRaycasts(Ray screenRay)
        {
            bool somethingFound = false;

            //first check for interactable Object
            var count = Physics.SphereCastNonAlloc(screenRay, 1.0f, _raycastHitCache, 1000.0f, _interactableLayer);
            if (count > 0)
            {
                for (var i = 0; i < count; ++i)
                {
                    var obj = _raycastHitCache[0].collider.GetComponent<HighlightableObject>();
                    
                    if (!obj)
                        continue;
                    SwitchHighlightedObject(obj);
                    somethingFound = true;
                    break;
                }
            }

            if (!somethingFound && highlighted)
            {
                SwitchHighlightedObject(null);
            }
        }


        private void SwitchHighlightedObject(HighlightableObject obj)
        {
            if (highlighted)
                highlighted.DeHighlight();

            highlighted = obj;
            if (highlighted)
                highlighted.Highlight();
            
        }
    }
}