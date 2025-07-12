using System;
using System.Linq;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Attack : MonoBehaviour
    {
        public EnemyAntAnimator Animator;
        public float AttackCooldown = 3f;
        private float Damage = 10f;
        
        private IGameFactory _gameFactory;
        private Transform _heroTransform;
        private float _attackCooldown;
        private bool _isAttacking;
        private Collider2D[] _hits = new Collider2D[1];
        private float Cleavage = 0.5f;
        private int _layerMask;
        private float EfectiveDistance = 0.1f;
        private bool _attackIsActive = true;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _gameFactory.HeroCreated += OnHeroCreated;

            _layerMask = 1 << LayerMask.NameToLayer("Player");
        }

        private void Update()
        {
            UpdateCooldown();

            if(CanAttack())
                StartAttack();
        }
        
        private void StartAttack()
        {
            LookAtAgent();

            //.LookAt(_heroTransform); //Может быть ошибка так как у меня 2д игра
            Animator.PlayAttack(); //Пока что вместо атаки вызываем состояние ожидания
            
            _isAttacking = true;
        }


        private void OnAttack()
        {
            if (Hit(out Collider2D hit))
            {
                PhysicsDebug.DrowDebug(StartPoin(), Cleavage, 2);
                hit.transform.GetComponent<HeroHealth>().TakeDamage(Damage);
                //Debug.Log("Hit on Hero");
            }    
        }

        private bool Hit(out Collider2D hit)
        {
            Vector2 startPosition = StartPoin();
            int hitsCount = Physics2D.OverlapCircleNonAlloc(startPosition, Cleavage, _hits, _layerMask);
            hit = _hits.FirstOrDefault();
            
            return hitsCount > 0;
        }
        private void LookAtAgent()
        {
            Vector2 direction = _heroTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private Vector2 StartPoin() => 
            (Vector2)transform.position + (Vector2)transform.right * EfectiveDistance;

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
            _attackIsActive && !_isAttacking && CooldownIsUp();
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