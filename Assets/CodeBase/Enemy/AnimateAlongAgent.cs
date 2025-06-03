using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAntAnimator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimateAlongAgent : MonoBehaviour
    { 
        public EnemyAntAnimator Animator;
        public NavMeshAgent Agent;
        
        private const float MinimalVelocity = 0.1f;

        private void Update()
        {
            if(ShouldMove())
                Animator.PlayWalk();
            else
                Animator.PlayIdle();
        }

        private bool ShouldMove() => 
            Agent.velocity.magnitude > MinimalVelocity && Agent.remainingDistance > Agent.radius;
    }
}