using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorlData WorldData;
        public KillData KillData;
        public State HeroState;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorlData(initialLevel);
            KillData = new KillData();
            HeroState = new State();
        }
    }
}