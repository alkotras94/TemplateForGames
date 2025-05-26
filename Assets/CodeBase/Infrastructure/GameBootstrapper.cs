using UnityEngine;
using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Logic;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain CurtainPrefafb;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(CurtainPrefafb));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);

        }
    }
}