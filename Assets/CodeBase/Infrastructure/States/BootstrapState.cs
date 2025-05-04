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

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>("SampleScene");

        private void RegisterServices()
        {
            AllServices.Container.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IAsset>()));
        }

        public void Exit()
        {

        }
    }
}