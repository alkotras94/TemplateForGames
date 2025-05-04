using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
    }
}