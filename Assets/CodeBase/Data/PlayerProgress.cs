using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorlData WorldData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorlData(initialLevel);
        }
    }
}