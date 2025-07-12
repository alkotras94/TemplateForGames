using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        public Animator _animator;
        private const string WalkPath = "Walk";
        private const string IdlePath = "Idle";
        private const string Death = "Death";

        public void Walk(Vector2 dir)
        {
            _animator.SetFloat(WalkPath, dir.sqrMagnitude);
        }

        public void Idle(Vector2 dir)
        {
            _animator.SetFloat(IdlePath, dir.sqrMagnitude);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger(Death);
        }
    }
}