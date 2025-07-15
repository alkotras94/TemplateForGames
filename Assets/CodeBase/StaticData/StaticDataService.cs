using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeID, EnemyStaticData> _enemy;

        public void LoadEnemy()
        {
            _enemy = Resources.LoadAll<EnemyStaticData>("StaticData/Enemy")
                .ToDictionary(x => x.EnemyTypeID, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeID enemyTypeID) => 
            _enemy.TryGetValue(enemyTypeID, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData : null;
    }
}