using Assets.CodeBase.AssetManagment;
using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services;
using System;

namespace Assets.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = allServices;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>("SampleScene");

        private void RegisterServices()
        {
            _services.RegisterSingle<IAsset>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAsset>()));
        }

        public void Exit()
        {

        }
    }
}