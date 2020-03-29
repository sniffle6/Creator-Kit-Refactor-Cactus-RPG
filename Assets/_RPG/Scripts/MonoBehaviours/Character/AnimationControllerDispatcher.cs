using UnityEngine;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class AnimationControllerDispatcher : MonoBehaviour
    {
        public interface IAttackFrameReceiver
        {
            void AttackFrame();
        }
    
        public interface IFootStepFrameReceiver
        {
            void FootstepFrame();
        }

        public MonoBehaviour attackFrameReceiver;
        public MonoBehaviour footstepFrameReceiver;

        private IAttackFrameReceiver _attackFrameReceiver;
        private IFootStepFrameReceiver _footStepFrameReceiver;

        private void Awake()
        {
            if (attackFrameReceiver != null)
            {

                _attackFrameReceiver = attackFrameReceiver as IAttackFrameReceiver;

                if (_attackFrameReceiver == null)
                {
                    Debug.LogError(
                        "the Monobehaviour set as Attack Frame Receiver does not implement the IAttackFrameReceiver interface!",
                        attackFrameReceiver);
                }
            }


            if (footstepFrameReceiver)
            {
                _footStepFrameReceiver = footstepFrameReceiver as IFootStepFrameReceiver;

                if (_attackFrameReceiver == null)
                {
                    Debug.LogError(
                        "the Monobehaviour set as Footstep Frame Receiver does not implement the IFootstepFrameReceiver interface!",
                        footstepFrameReceiver);
                }
            }
        }


        private void AttackEvent()
        {
            _attackFrameReceiver?.AttackFrame();
        }

        private void FootstepEvent()
        {
            _footStepFrameReceiver?.FootstepFrame();
        }
    
    }
}



































