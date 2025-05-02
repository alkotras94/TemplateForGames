using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private const string InitialPointTag = "InitialPoint";
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName)
    {
        _sceneLoader.Load(sceneName, onLoaded);
    }

    public void Exit()
    {
        
    }

    private void onLoaded()
    {
        var initialPoint = GameObject.FindWithTag(InitialPointTag);

        GameObject player = Instantiate("Player/Player", initialPoint.transform.position);
    }

    private static GameObject Instantiate(string path)
    {
        var playerPrefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(playerPrefab);
    }

    private static GameObject Instantiate(string path, Vector2 at)
    {
        var playerPrefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(playerPrefab, at, Quaternion.identity);
    }
}