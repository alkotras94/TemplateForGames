using System;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        public EnemyTypeID TypeId;
        public bool Slain => _slain;
        private string _id;
        private bool _slain;
        private IGameFactory _factory;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }
        public void LoadProgress(PlayerProgress playerProgress)
        {
            if(playerProgress.KillData.ClearedSpawners.Contains(_id))
                _slain = true;
            else
                Spawn();
        }
        public void UpdateProgress(PlayerProgress playerProgress)
        {
            if (_slain)
                playerProgress.KillData.ClearedSpawners.Add(_id);
        }
        private void Spawn()
        {
            _factory.CreateEnemy(TypeId, transform);
        }
    }
}