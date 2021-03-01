using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputControls _inputControls;

    public event Action<bool> OnPauseButton;
    public Vector2 Axis { get; private set; }
    public bool InteructButton { get; private set; }
    private bool _pauseButton;
    public bool PauseButton 
    {
        get => _pauseButton;
        private set
        {
            _pauseButton = value;
            OnPauseButton?.Invoke(_pauseButton);
        }
    }
    private void Start()
    {
        _inputControls = new InputControls();

        _inputControls.Gameplay.Movement.performed += context => Axis = context.ReadValue<Vector2>();
        _inputControls.Gameplay.Interuct.performed += context => InteructButton = context.ReadValueAsButton();
        _inputControls.Gameplay.Pause.performed += context => PauseButton = !PauseButton;

        _inputControls.Enable();
    }
    private void OnDisable() => _inputControls.Disable();
}
