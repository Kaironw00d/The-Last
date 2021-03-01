using UnityEngine;

public enum GameState
{
    PREBOOT,
    BOOT,
    MAIN_MENU,
    SETTINGS,
    GAMEPLAY
}

public class GameManager : MonoBehaviour
{
    public delegate void OnStateChangeHandler();
    public event OnStateChangeHandler OnStateChange;
    public delegate void OnGamePauseHandler();
    public event OnGamePauseHandler OnGamePause;
    public GameState CurrentState { get; private set; }

    private void Start() => SetGameState(GameState.BOOT);

    public void SetGameState(GameState state)
    {
        CurrentState = state;
        OnStateChange?.Invoke();
    }
    public void PauseGame()
    {
        OnGamePause?.Invoke();
    }
}
