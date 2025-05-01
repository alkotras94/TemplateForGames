using System;

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

    private void EnterLoadLevel()
    {
        _gameStateMachine.Enter<LoadLevelState>();
    }

    private void RegisterServices()
    {
        
    }

    public void Exit()
    {
        
    }
}
