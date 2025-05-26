using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    { 
        public GameBootstrapper BootstrapperPrefab;
        private void Awake()
        {
            var gameBootstraper = FindAnyObjectByType<GameBootstrapper>();

            if (gameBootstraper == null)
                Instantiate(BootstrapperPrefab);
        }
    }
}