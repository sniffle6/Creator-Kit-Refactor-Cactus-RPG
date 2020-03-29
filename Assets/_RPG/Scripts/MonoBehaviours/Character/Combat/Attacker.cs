using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _RPG.Scripts.MonoBehaviours.Character.Combat
{
    public class Attacker : MonoBehaviour, ICanInteract, AnimationControllerDispatcher.IAttackFrameReceiver
    {
        private Character _interactingObject;
        private AttackableObject _attackableObject;
        private Animator _animator;
        private int _attackParamId;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            _attackParamId = Animator.StringToHash("Attack");
        }

        public void Interact(Character interacter, InteractableObject interactingWith)
        {
            if (!(interactingWith is AttackableObject attackable))
                return;

            _interactingObject = interacter;

            if (attackable.isAttackable == false)
            {
                attackable.InteractWith(interacter);
                return;
            }

            _attackableObject = attackable;

            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                _animator.SetTrigger(_attackParamId);
        }


        public void AttackFrame()
        {
            _attackableObject.Attacked(_interactingObject, new Attack(Random.Range(0, 50), Random.Range(0, 2) == 1));
        }
    }
}