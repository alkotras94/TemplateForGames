using CodeBase.StaticData;

namespace Assets.CodeBase.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadEnemy();
        EnemyStaticData ForEnemy(EnemyTypeID enemyTypeID);
    }
}