using UnityEngine;
using TMPro.EditorUtilities;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public LoadingCurtain LoadingCurtain;
    private Game _game;

    private void Awake()
    {
        _game = new Game(this, LoadingCurtain);
        _game.GameStateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad(this);

    }
}
