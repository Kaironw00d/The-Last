using System;
using UnityEngine;
using Zenject;

public class PauseState : MonoBehaviour
{
    private GameManager _gameManager;
    private PauseUI _pauseUI;

    [Inject] private void Construct(GameManager gameManager, PauseUI pauseUI)
    {
        _gameManager = gameManager;
        _pauseUI = pauseUI;

        _gameManager.OnGamePause += HandlePause;
        _pauseUI.OnRestartButtonClick += RestartLevel;
        _pauseUI.OnRestartButtonClick += ReturnToMenu;
        _pauseUI.OnQuitButtonClick += Quit;
        _pauseUI.OnResumeButtonClick += ResumeGame;
    }
    private void HandlePause()
    {
        _pauseUI.gameObject.SetActive(true);
        PauseGame();
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private void RestartLevel()
    {
        throw new NotImplementedException();
    }
    private void ReturnToMenu()
    {
        throw new NotImplementedException();
    }
    private void Quit()
    {
        throw new NotImplementedException();
    }
    private void ResumeGame()
    {
        _pauseUI.Hide();
        Time.timeScale = 1f;
    }
}
