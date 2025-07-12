using System;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        public HeroHealth Health;
        public HeroMove Move;
        public HeroAnimator Animator;

        public GameObject DeadFx;
        private bool _isDeath = false;

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            Debug.Log("Паскуда, твои жизни " + Health.Current);
            if (!_isDeath && Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _isDeath = true;
            
            Move.enabled = false;
            Animator.PlayDeath();

            Instantiate(DeadFx, transform.position, Quaternion.identity);
            Debug.Log("Падаль");
        }
    }
}