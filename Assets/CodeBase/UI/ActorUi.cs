using System;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUi : MonoBehaviour
    {
        public HpBar HpBar;
        private HeroHealth _heroHealth;

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.HealthChanged += UpdateHpBar;
        }
        
        public void UpdateHpBar()
        {
            HpBar.SetValue(_heroHealth.Current, _heroHealth.MaxHp);
        }

        private void OnDestroy()
        {
            _heroHealth.HealthChanged -= UpdateHpBar;
        }
    }
}