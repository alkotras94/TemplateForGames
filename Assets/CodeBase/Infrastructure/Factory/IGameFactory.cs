using System;
using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject HeroGameObject { get; }
        event Action HeroCreated;
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWrites { get; }
        void Cleanup();
        void Register(ISavedProgressReader progressReader);

    }
}