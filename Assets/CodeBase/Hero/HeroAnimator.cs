using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        public Animator _animator;
        private const string WalkPath = "Walk";
        private const string IdlePath = "Idle";
        
        public void Walk(Vector2 dir)
        {
            _animator.SetFloat(WalkPath, dir.sqrMagnitude);
        }

        public void Idle(Vector2 dir)
        {
            _animator.SetFloat(IdlePath, dir.sqrMagnitude);
        }
    }
}