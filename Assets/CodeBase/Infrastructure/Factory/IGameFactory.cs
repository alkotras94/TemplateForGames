using System;
using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWrites { get; }
        void Cleanup();
        void Register(ISavedProgressReader progressReader);

        GameObject CreateEnemy(EnemyTypeID typeId, Transform transform);
    }
}