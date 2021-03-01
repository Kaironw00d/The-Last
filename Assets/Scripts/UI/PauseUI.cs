using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class PauseUI : MonoBehaviour
{
    public event Action OnRestartButtonClick;
    public event Action OnMenuButtonClick;
    public event Action OnQuitButtonClick;
    public event Action OnResumeButtonClick;
    private Button _restartButton;
    private Button _menuButton;
    private Button _quitButton;
    private PlayerInput _input;
    private UITweener _tweener;

    [Inject] private void Construct(
        [Inject(Id = "Pause_Restart")] Button restartButton,
        [Inject(Id = "Pause_Menu")] Button menuButton,
        [Inject(Id = "Pause_Quit")] Button quitButton,
        PlayerInput input,
        [Inject(Id = "Pause_Tweener")] UITweener tweener)
    {
        _restartButton = restartButton;
        _menuButton = menuButton;
        _quitButton = quitButton;
        _input = input;
        _tweener = tweener;

        _restartButton.onClick.AddListener(Restart);
        _menuButton.onClick.AddListener(ReturnToMenu);
        _quitButton.onClick.AddListener(Quit);
        _input.OnPauseButton += Resume;
    }
    public void Hide()
    {
        _tweener.Disable();
    }
    private void Restart()
    {
        OnRestartButtonClick?.Invoke();
    }
    private void ReturnToMenu()
    {
        OnMenuButtonClick?.Invoke();
    }
    private void Resume(bool value)
    {
        if(!value)
            OnResumeButtonClick?.Invoke();
    }
    private void Quit()
    {
        OnQuitButtonClick?.Invoke();
    }
}
