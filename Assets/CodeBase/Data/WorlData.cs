using System;

namespace CodeBase.Data
{
    [Serializable]
    public class WorlData
    {
        public PositionOnLevel PositionOnLevel;

        public WorlData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel);
        }
    }
}