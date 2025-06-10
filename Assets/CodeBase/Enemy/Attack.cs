using System;
using System.Linq;
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
        private Collider2D[] _hits = new Collider2D[1];
        private float Cleavage = 1f;
        private int _layerMask;
        private float EfectiveDistance;
        private bool _attackIsActive = true;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _gameFactory.HeroCreated += OnHeroCreated;

            Cleavage = 1 << LayerMask.NameToLayer("Player");
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
            Animator.PlayAttack(); //Пока что вместо атаки вызываем состояние ожидания
            
            _isAttacking = true;
        }

        private void OnAttack()
        {
            if (Hit(out Collider2D hit))
            {
                PhysicsDebug.DrowDebug(StartPoin(), Cleavage, 2);
            }    
        }

        private bool Hit(out Collider2D hit)
        {
            Vector2 startPosition = StartPoin();
            int hitsCount = Physics2D.OverlapCircleNonAlloc(startPosition, Cleavage, _hits, _layerMask);
            hit = _hits.FirstOrDefault();
            
            return hitsCount > 0;
        }

        private Vector2 StartPoin() => 
            new Vector2(transform.position.x, transform.position.y) * transform.forward * EfectiveDistance;

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
        
        private bool CanAttack() => 
            _attackIsActive && _isAttacking && CooldownIsUp();
        private bool CooldownIsUp() => 
            _attackCooldown <= 0f;
        private void OnHeroCreated() => 
            _heroTransform = _gameFactory.HeroGameObject.transform;

        public void EnableAttack() => 
            _attackIsActive = true;

        public void DisableAttack() => 
            _attackIsActive = false;
    }
}