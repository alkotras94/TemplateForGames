using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/EnemyData")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeID EnemyTypeID;
        [Range(1, 100)]
        public int HP;
        [Range(1,30)]
        public float Damage;
        [Range(0.5f,1f)]
        public float EffectiveDistance;
        [Range(0.5f,1f)]
        public float Cleavage;
        public GameObject Prefab;
    }
}