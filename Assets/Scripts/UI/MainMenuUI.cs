using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnPlayButtonClick;
    public event Action OnSettingsButtonClick;
    public event Action OnQuitButtonClick;

    private Button _playButton;
    private Button _settingsButton;
    private Button _quitButton;
    private UITweener _tweener;
    private Animation _cameraAnimation;

    [Inject] private void Construct(
        [Inject(Id = "Play")] Button playButton,
        [Inject(Id = "Settings")] Button settingButton,
        [Inject(Id = "Quit")] Button quitButton,
        [Inject(Id = "MainMenu_Tweener")] UITweener tweener,
        Animation cameraAnimation)
    {
        _playButton = playButton;
        _settingsButton = settingButton;
        _quitButton = quitButton;
        _tweener = tweener;
        _cameraAnimation = cameraAnimation;

        _playButton.onClick.AddListener(Play);
        _settingsButton.onClick.AddListener(OpenSettings);
        _quitButton.onClick.AddListener(Quit);
    }
    private void Play()
    {
        _tweener.Disable();
        _cameraAnimation.Play();
        OnPlayButtonClick?.Invoke();
    }
    private void OpenSettings()
    {
        OnSettingsButtonClick?.Invoke();
    }
    private void Quit()
    {
        OnQuitButtonClick?.Invoke();
    }
}
