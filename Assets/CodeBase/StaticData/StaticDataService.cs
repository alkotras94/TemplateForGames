using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.Infrastructure.Services;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeID, EnemyStaticData> _enemy;
        private IStaticDataService _staticDataServiceImplementation;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void LoadEnemy()
        {
            _enemy = Resources.LoadAll<EnemyStaticData>("StaticData/Enemy")
                .ToDictionary(x => x.EnemyTypeID, x => x);
            
            _windowConfigs = Resources.Load<WindowStaticData>("StaticData/UI/WindowConfig")
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeID enemyTypeID) => 
            _enemy.TryGetValue(enemyTypeID, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData : null;

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig) 
                ? windowConfig : null;
    }
}