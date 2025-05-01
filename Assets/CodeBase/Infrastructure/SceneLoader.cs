using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

    public void Load(string nameScene, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadScene(nameScene, onLoaded));

    public IEnumerator LoadScene(string nameScene, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == nameScene)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nameScene);

        while (!waitNextScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}