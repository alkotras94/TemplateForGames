using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private NavMeshAgent _agent;
        void Start()	{
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Update()
        {
            PositionFixationZ();
        }

        private void PositionFixationZ()
        {
            Vector3 pos = transform.position;
            pos.z = 0f; 
            transform.position = pos;
        }
    }
}