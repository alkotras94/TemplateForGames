using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "StaticData/Create WindowConfig")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}