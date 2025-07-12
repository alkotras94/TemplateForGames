using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISavedProgress
    {
        private State _state;
        public event Action HealthChanged; 

        public float Current
        {
            get => _state.CurrentHp;
            set
            {
                if (_state.CurrentHp != value)
                {
                _state.CurrentHp = value;
                HealthChanged?.Invoke();
                }
            } 
        }

        public float MaxHp
        {
            get => _state.MaxHp; 
            set => _state.MaxHp = value;
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            _state = playerProgress.HeroState;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.HeroState.CurrentHp = Current;
            playerProgress.HeroState.MaxHp = MaxHp;
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
            {
                return;
            }
            
            Current -= damage;
        }
    }
}