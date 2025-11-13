using System;
using Assets.CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;
        
        protected IPersistentProgressService  PersistentProgressService;
        public PlayerProgress Progress => PersistentProgressService.Progress;
        
        public void Construct(IPersistentProgressService persistentProgressService)
        {
            PersistentProgressService = persistentProgressService;
        }
        
        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(()=> Destroy(gameObject));
        }
        
        protected virtual void Initialize(){}
        protected virtual void SubscribeUpdates(){}
        protected virtual void Cleanup(){}
    }
}