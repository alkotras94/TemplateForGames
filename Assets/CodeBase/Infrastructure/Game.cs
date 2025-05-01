using System;
public class Game
{
    public GameStateMachine GameStateMachine;

    public Game(ICoroutineRunner coroutineRunner)
	{
		GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
	}
}

