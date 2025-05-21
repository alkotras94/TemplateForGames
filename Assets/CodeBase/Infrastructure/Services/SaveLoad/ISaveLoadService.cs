using Assets.CodeBase.Infrastructure.Services;
using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}