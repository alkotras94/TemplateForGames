using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.Services.PersistentProgress;
using Assets.CodeBase.Logic;
using CodeBase.Hero;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string EnemySpawnerTag = "EnemySpawner";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, onLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void onLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void InitGameWorld()
        {
            GameObject player = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag));
            GameObject hud = _gameFactory.CreateHud();
            
            hud.GetComponentInChildren<ActorUi>().Construct(player.GetComponent<HeroHealth>());
            _gameStateMachine.Enter<GameLoopState>();
            InitSpawners();
        }

        private void InitSpawners()
        {
            foreach (GameObject spawnerObject in GameObject.FindGameObjectsWithTag(EnemySpawnerTag))
            {
                var spawner = spawnerObject.GetComponent<EnemySpawner>();
                _gameFactory.Register(spawner);
            }
        }
    }
}