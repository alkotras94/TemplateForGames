using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.AssetManagment
{
    public interface IAsset : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector2 at);
    }
}