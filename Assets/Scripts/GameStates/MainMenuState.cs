using UnityEngine;
using Zenject;

public class MainMenuState : MonoBehaviour
{
    private GameManager _gameManager;
    private MainMenuUI _mainMenuUI;

    [Inject] private void Construct(GameManager gameManager, MainMenuUI mainMenuUI)
    {
        _gameManager = gameManager;
        _mainMenuUI = mainMenuUI;

        _gameManager.OnStateChange += HandleOnStateChange;
        _mainMenuUI.OnPlayButtonClick += () => _gameManager.SetGameState(GameState.GAMEPLAY);
        _mainMenuUI.OnSettingsButtonClick += () => _gameManager.SetGameState(GameState.SETTINGS);
        _mainMenuUI.OnQuitButtonClick += Quit;
    }
    private void HandleOnStateChange()
    {
        if(_gameManager.CurrentState == GameState.MAIN_MENU)
            _mainMenuUI.gameObject.SetActive(true);
    }
    private void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit ();
        #endif
    }
}
