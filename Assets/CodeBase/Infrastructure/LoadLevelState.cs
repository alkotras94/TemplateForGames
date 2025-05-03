using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private const string InitialPointTag = "InitialPoint";
    private const string PlayerPath = "Player/Player";
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;

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
        var initialPoint = GameObject.FindWithTag(InitialPointTag);

        GameObject player = Instantiate(PlayerPath, initialPoint.transform.position);

        _gameStateMachine.Enter<GameLoopState>();
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