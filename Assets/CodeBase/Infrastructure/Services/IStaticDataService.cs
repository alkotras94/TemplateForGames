using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadEnemy();
        EnemyStaticData ForEnemy(EnemyTypeID enemyTypeID);
        WindowConfig ForWindow(WindowId windowId);
    }
}