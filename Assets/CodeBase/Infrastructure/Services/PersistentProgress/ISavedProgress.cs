using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress playerProgress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress playerProgress);
    }
}