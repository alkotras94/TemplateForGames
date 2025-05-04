using UnityEngine;

namespace Assets.CodeBase.AssetManagment
{
    public class AssetProvider : IAsset
    {
        public GameObject Instantiate(string path)
        {
            var playerPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(playerPrefab);
        }

        public GameObject Instantiate(string path, Vector2 at)
        {
            var playerPrefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(playerPrefab, at, Quaternion.identity);
        }
    }
}