using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Logic;
using System;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
        }
    }
}