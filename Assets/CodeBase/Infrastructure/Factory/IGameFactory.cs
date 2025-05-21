using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressesWrites { get; }
        void Cleanup();
    }
}