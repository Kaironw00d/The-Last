using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootState : MonoBehaviour
{
    private GameManager _gameManager;
    private BootUI _bootUI;

    [Inject] private void Construct(GameManager gameManager, BootUI bootUI)
    {
        _gameManager = gameManager;
        _bootUI = bootUI;

        _gameManager.OnStateChange += HandleOnStateChange;
    }
    private void HandleOnStateChange()
    {
        if(_gameManager.CurrentState == GameState.BOOT)
        {
            _bootUI.gameObject.SetActive(true);
            StartCoroutine(LoadMainScene());
        }
    }
    private IEnumerator LoadMainScene()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        
        while(!loadingOperation.isDone)
        {
            _bootUI.SetLoadingProgress(Mathf.Clamp01(loadingOperation.progress / 0.9f));
            yield return null;
        }
        _bootUI.Hide();
        yield return new WaitForSeconds(0.5f);
        SceneManager.UnloadSceneAsync("Boot");
        _gameManager.SetGameState(GameState.MAIN_MENU);
    }
}
