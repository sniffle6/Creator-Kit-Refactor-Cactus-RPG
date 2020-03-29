using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _RPG.Scripts.MonoBehaviours.Character
{
    public class NavMeshMover : MonoBehaviour, IMove
    {
        public float speed = 10.0f;


        private NavMeshAgent _agent;
        private Transform _transform;


        private void Start()
        {
            _transform = transform;
            _agent = GetComponent<NavMeshAgent>();
            (_agent.speed, _agent.angularSpeed) = (speed, 360.0f);
        }

        public void InitializeMove(Vector3 position)
        {
            NavMesh.SamplePosition(position, out var hit, 1.5f, NavMesh.AllAreas);
            _agent.SetDestination(hit.position);
        }

        public void StopMove()
        {
            _agent.ResetPath();
            _agent.velocity = Vector3.zero;
        }

        public void FacePosition(Vector3 position)
        {
            _transform.LookAt(position);
        }
    }
}