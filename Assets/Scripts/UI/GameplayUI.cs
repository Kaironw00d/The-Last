using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayUI : MonoBehaviour
{
    public event Action OnPauseButtonClick;
    private PlayerInput _input;
    private ProgressBar _hungerProgressBar;
    private ProgressBar _freezeProgressBar;
    private TMP_Text _dayText;
    private PlayerHunger _playerHunger;
    private PlayerHypothermia _playerHypo;
    private DayCycleService _dayCycleService;
    [Inject] private void Construct(
        PlayerInput input,
        [Inject(Id = "Hunger")] ProgressBar hungerProgressBar,
        [Inject(Id = "Freeze")] ProgressBar freezeProgressBar,
        [Inject(Id = "Day")] TMP_Text dayText,
        PlayerHunger playerHunger,
        PlayerHypothermia playerHypo,
        DayCycleService dayCycleService)
    {
        _input = input;
        _hungerProgressBar = hungerProgressBar;
        _freezeProgressBar = freezeProgressBar;
        _dayText = dayText;
        _playerHunger = playerHunger;
        _playerHypo = playerHypo;
        _dayCycleService = dayCycleService;

        _input.OnPauseButton += value => 
        {
            if(value)
                OnPauseButtonClick?.Invoke();
        };
        _playerHunger.OnHungerChange += value => _hungerProgressBar.SetProgress(value);
        _playerHypo.OnHypothermiaChange += value => _freezeProgressBar.SetProgress(value);
        _dayCycleService.OnDayChange += value => _dayText.text = $"Day: {value}";
    }
}
