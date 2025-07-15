using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    public class RotateToHero : Follow
    {
        public float Speed = 1;
        private Transform _heroTransform;
        private Vector2 _positionToLook;
        private IGameFactory  _gameFactory;

        public void Construct(Transform heroTransform)
        {
            _heroTransform = heroTransform;
        }

        private void Update()
        {
            if (Initialized())
                RotateTowardsHero();
        }
        
        private void RotateTowardsHero()
        {
            UpdatePositionToLookAt();
        }

        private void UpdatePositionToLookAt()
        {
            Vector2 positionFiff = _heroTransform.position - transform.position;
            var angle = Calculate(positionFiff.y, positionFiff.x);
            transform.rotation =  TargetRotation(angle);
            //_positionToLook = new Vector2(positionFiff.x, positionFiff.y);
        }
        private Quaternion TargetRotation(float angle) => 
            Quaternion.Euler(0, 0, angle);
        private float Calculate (float y, float x) =>
            Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        
        private bool Initialized() => 
            _heroTransform != null;
    }
}