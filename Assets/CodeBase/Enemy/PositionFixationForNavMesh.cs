using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class PositionFixationForNavMesh : MonoBehaviour
    {   
        private NavMeshAgent Agent;

        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.updateRotation = false;
            Agent.updateUpAxis = false;
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