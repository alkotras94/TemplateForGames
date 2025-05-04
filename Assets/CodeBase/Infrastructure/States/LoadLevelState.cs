using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, onLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void onLoaded()
        {
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPointTag));

            _gameStateMachine.Enter<GameLoopState>();
        }

    }
}