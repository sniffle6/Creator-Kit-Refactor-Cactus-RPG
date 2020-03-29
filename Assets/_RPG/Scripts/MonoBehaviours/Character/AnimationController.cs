using _RPG.Scripts.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class AnimationController : MonoBehaviour, AnimationControllerDispatcher.IFootStepFrameReceiver
    {
        private Transform _transform;
        private Animator _animator;
        private NavMeshAgent _agent;
        
        private int _speedParamId;

        private void Awake() => (_agent, _transform, _animator) = (GetComponent<NavMeshAgent>(), transform, GetComponentInChildren<Animator>());

        private void Start() => _speedParamId = Animator.StringToHash("Speed");
        
        private void Update() => _animator.SetFloat(_speedParamId, _agent.velocity.magnitude / _agent.speed);
        


        public void FootstepFrame()
        {
            VfxManager.PlayVfx(VfxType.StepPuff, _transform.position);
        }
    }
}
