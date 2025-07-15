using System;
using System.Collections.Generic;
using Assets.CodeBase.AssetManagment;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;
using Object = System.Object;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAsset _assetProvider;
        private IGameFactory _gameFactoryImplementation;
        private readonly IStaticDataService _staticData;


        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress>  ProgressesWrites { get; } = new List<ISavedProgress>();
        public GameFactory(IAsset assets, IStaticDataService staticData)
        {
            _assetProvider = assets;
            _staticData = staticData;
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
        public GameObject CreateEnemy(EnemyTypeID typeId, Transform parent)
        {
            EnemyStaticData enemyData =  _staticData.ForEnemy(typeId);
            GameObject enemy = GameObject.Instantiate(enemyData.Prefab, parent.position, Quaternion.identity);

            return enemy;
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

        public void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressesWrites.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }

    }
}