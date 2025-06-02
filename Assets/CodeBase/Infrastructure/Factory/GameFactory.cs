using System;
using System.Collections.Generic;
using Assets.CodeBase.AssetManagment;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAsset _assetProvider;
        

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress>  ProgressesWrites { get; } = new List<ISavedProgress>();
        public GameFactory(IAsset assets)
        {
            _assetProvider = assets;
        }
        
        public GameObject CreateHud() =>
            _assetProvider.Instantiate(AssetPath.Hud);


        public GameObject HeroGameObject { get; set; }
        public event Action HeroCreated;

        public GameObject CreateHero(GameObject at)
        {
            HeroGameObject = InstantiateRegistred(AssetPath.PlayerPath, at.transform.position);
            HeroCreated?.Invoke();
            return HeroGameObject;
        }

        private GameObject InstantiateRegistred(string prefabPath, Vector3 position)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath, position);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressesWrites.Clear();
        }
        
        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressesWrites.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}