using UnityEngine;
using Zenject;

public class GameplayState : MonoBehaviour
{
    private GameManager _gameManager;
    private PlayerHunger _playerHunger;
    private PlayerHypothermia _playerHypo;
    private GameplayUI _gameplayUI;

    [Inject] private void Construct(GameManager gameManager, PlayerHunger playerHunger, PlayerHypothermia playerHypo, GameplayUI gameplayUI)
    {
        _gameManager = gameManager;
        _playerHunger = playerHunger;
        _playerHypo = playerHypo;
        _gameplayUI = gameplayUI;
        
        _gameManager.OnStateChange += HandleOnStateChange;
        _gameplayUI.OnPauseButtonClick += PauseGame;
    }
    private void HandleOnStateChange()
    {
        if(_gameManager.CurrentState == GameState.GAMEPLAY)
        {
            _gameplayUI.gameObject.SetActive(true);
            _playerHunger.StartProcess();
            _playerHypo.StartProcess();
        }
    }
    private void PauseGame()
    {
        //_gameplayUI.gameObject.SetActive(false);
        _gameManager.PauseGame();
    }
}
