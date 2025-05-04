using Assets.CodeBase.AssetManagment;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAsset _assetProvider;

        public GameFactory(IAsset assets)
        {
            _assetProvider = assets;
        }

        public GameObject CreatePlayer(GameObject at) =>
            _assetProvider.Instantiate(AssetPath.PlayerPath, at.transform.position);
    }
}