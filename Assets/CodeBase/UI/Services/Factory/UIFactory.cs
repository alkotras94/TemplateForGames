using Assets.CodeBase.AssetManagment;
using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAsset _asset;
        private readonly IPersistentProgressService persistentProgressService;
        private IStaticDataService _staticData;
        private Transform _uiRoot;
        

        public UIFactory(IAsset asset, IStaticDataService staticData, IPersistentProgressService persistentProgressService)
        {
            _asset = asset;
            _staticData = staticData;
            this.persistentProgressService = persistentProgressService;
        }

        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
            window.Construct(persistentProgressService);
        }

        public void CreateUIRoot()
        {
            _uiRoot = _asset.Instantiate(UIRootPath).transform;
        }
    }
}