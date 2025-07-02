using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        public EnemyTypeID TypeId;
        private string _id;

        public bool Slain;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
        }
        public void LoadProgress(PlayerProgress playerProgress)
        {
            if(playerProgress.KillData.ClearedSpawners.Contains(_id))
                Slain = true;
            else
                Spawn();
        }
        public void UpdateProgress(PlayerProgress playerProgress)
        {
            if (Slain)
                playerProgress.KillData.ClearedSpawners.Add(_id);
        }
        private void Spawn()
        {
            
        }
    }
}