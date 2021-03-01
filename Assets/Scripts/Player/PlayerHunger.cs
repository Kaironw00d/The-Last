using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerHunger : MonoBehaviour
{
    public event Action<float> OnHungerChange;
    [Range(1, 200)] public int maxHungerValue = 100;
    [Range(1, 200)] public int baseHungerValue = 20;
    private int _currentHungerValue;
    public int CurrentHungerValue
    {
        get => _currentHungerValue;
        set
        {
            _currentHungerValue = value;
            if(_currentHungerValue < 0)
                _currentHungerValue = 0;

            OnHungerChange?.Invoke((float)_currentHungerValue / maxHungerValue);
        }
    }
    public int hungerOverTime = 3;
    public float impactDelay = 2;
    private WaitForSeconds _delay;
    private PlayerInput _input;
    private IFoodSource _foodSource;

    [Inject] private void Construct(PlayerInput input)
    {
        _input = input;
        _delay = new WaitForSeconds(impactDelay);
    }
    public void StartProcess()
    {
        CurrentHungerValue = baseHungerValue;
        StartCoroutine(HungerPlayerCoroutine());
    }
    private IEnumerator HungerPlayerCoroutine()
    {
        while(true)
        {
            CurrentHungerValue += hungerOverTime;
            yield return _delay;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _foodSource = other.GetComponent<IFoodSource>();
        if(_foodSource != null && _input.InteructButton)
        {
            _foodSource.Interuct();
            CurrentHungerValue -= _foodSource.Satiety;
        }
    }
}
