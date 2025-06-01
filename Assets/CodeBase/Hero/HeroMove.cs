using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.Input;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D _rb;
        private Vector2 _movement;
        private HeroAnimator _heroAnimator;
        private IInputService _inputService;
        private Camera _camera;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _inputService = AllServices.Container.Single<IInputService>();
            _camera = Camera.main;
            _heroAnimator = GetComponent<HeroAnimator>();
            CameraFollow();
        }

        void Update()
        {
                _movement.x = _inputService.Axis.x;
                _movement.y = _inputService.Axis.y;
                _movement = _movement.normalized;
                
                _heroAnimator.Walk(_movement);
        }

        void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
            
            if (_movement != Vector2.zero)
            {
                float angle = Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg - 0f;
                _rb.rotation = angle;
            }
        }
        
        public void UpdateProgress(PlayerProgress playerProgress) => 
            playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(),transform.position.AsVectorData());

        private void CameraFollow()
        {
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }
        private static string CurrentLevel() =>
            SceneManager.GetActiveScene().name;
        
        public void LoadProgress(PlayerProgress playerProgress)
        {
            if (CurrentLevel() == playerProgress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = playerProgress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null) 
                    Warp(to: savedPosition);
            }
        }

        private void Warp(Vector3Data to) => 
            transform.position = to.AsUnityVector();
    }
}

