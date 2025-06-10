using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAntAnimator : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private Animator _animator;
        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayDeath() => 
            _animator.SetTrigger(Die);

        public void PlayWalk() =>
            _animator.SetTrigger(Move);
        
        public void PlayIdle() =>
            _animator.SetTrigger(Idle);

        public void PlayAttack() => 
            _animator.SetTrigger(Attack);
    }
}