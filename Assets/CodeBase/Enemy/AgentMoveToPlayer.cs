using System;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : Follow
    {
        private const float MinimalDistance = 1f;
        
        public NavMeshAgent Agent;
        private Transform _heroTransform;
        
        private IGameFactory  _gameFactory;

        void Start()	{
            Agent = GetComponent<NavMeshAgent>();
            Agent.updateRotation = false;
            Agent.updateUpAxis = false;

            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += HeroCreated;
        }

        private void Update()
        {
            if (Initialized() && HeroNotReached())
            {
                Agent.destination = _heroTransform.position;
                RotationAgent();
            }
        }


        private bool Initialized() => 
            _heroTransform != null;

        private void HeroCreated() => 
            InitializeHeroTransform();

        private void InitializeHeroTransform() => 
            _heroTransform = _gameFactory.HeroGameObject.transform;
        private bool HeroNotReached() => 
            Vector2.Distance(Agent.destination, _heroTransform.position) > MinimalDistance;

        private void RotationAgent()
        {
            Vector2 direction = _heroTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}