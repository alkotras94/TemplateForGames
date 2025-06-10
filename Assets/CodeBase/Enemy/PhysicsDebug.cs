using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Enemy
{
    public static class PhysicsDebug
    {
        public static void DrowDebug(Vector2 worldPos, float radius, float second)
        {
            Debug.DrawRay(worldPos, radius * Vector2.up,Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector2.down,Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector2.left,Color.red, second);
            Debug.DrawRay(worldPos, radius * Vector2.right,Color.red, second);
        }
    }
}