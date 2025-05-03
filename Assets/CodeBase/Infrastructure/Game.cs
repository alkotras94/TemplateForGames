using System;
public class Game
{
    public GameStateMachine GameStateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
	{
		GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
	}
}

