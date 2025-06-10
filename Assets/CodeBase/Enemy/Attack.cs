using System;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Attack : MonoBehaviour
    {
        public EnemyAntAnimator Animator;
        public float AttackCooldown = 3f;
        
        private IGameFactory _gameFactory;
        private Transform _heroTransform;
        private float _attackCooldown;
        private bool _isAttacking;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _gameFactory.HeroCreated += OnHeroCreated;
        }

        private void Update()
        {
            UpdateCooldown();

            if(CanAttack())
                StartAttack();
        }
        
        private void StartAttack()
        {
            transform.LookAt(_heroTransform); //Может быть ошибка так как у меня 2д игра
            Animator.PlayIdle(); //Пока что вместо атаки вызываем состояние ожидания
            
            _isAttacking = true;
        }

        private void OnAttack(){}

        private void OnAttackEnded()
        {
            _attackCooldown = AttackCooldown;
            _isAttacking = false;
        }
        private void UpdateCooldown()
        {
            if(!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }
        
        private bool CanAttack() => _isAttacking && CooldownIsUp();
        private bool CooldownIsUp() => _attackCooldown <= 0f;
        private void OnHeroCreated() => _heroTransform = _gameFactory.HeroGameObject.transform;
    }
}