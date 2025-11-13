using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public KillData KillData;
        public State HeroState;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            KillData = new KillData();
            HeroState = new State();
        }
    }
}