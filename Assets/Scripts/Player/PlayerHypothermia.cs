using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerHypothermia : MonoBehaviour
{
    public event Action<float> OnHypothermiaChange;
    [Range(1, 200)] public int maxHypoValue = 100;
    [Range(1, 200)] public int baseHypoValue = 15;
    private int _currentHypoValue;
    public int CurrentHypoValue
    {
        get => _currentHypoValue;
        set
        {
            _currentHypoValue = value;
            if(_currentHypoValue < 0)
                _currentHypoValue = 0;
            
            OnHypothermiaChange?.Invoke((float)_currentHypoValue / maxHypoValue);
        }
    }
    public AnimationCurve difficultyCurve;

    private Coroutine _warmUpCoroutine;
    private int _currentDay;
    private int _freezeOverTime;
    [SerializeField] private float _impactDelay = 5f;
    private WaitForSeconds _delay;

    [Inject] private void Construct(DayCycleService dayCycleService)
    {
        _currentDay = dayCycleService.CurrentDay;

        dayCycleService.OnDayChange += currentDay => _currentDay = currentDay;

        _delay = new WaitForSeconds(_impactDelay);

    }
    public void StartProcess()
    {
        CurrentHypoValue = baseHypoValue;
        StartCoroutine(FreezePlayerCoroutine());
    }
    private void OnTriggerEnter(Collider other)
    {
        IWarmSource warmSource = other.GetComponent<IWarmSource>();
        if(warmSource != null)
        {
            _warmUpCoroutine = StartCoroutine(WarmUpPlayerCoroutine(warmSource.WarmUpOverTime));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IWarmSource warmSource = other.GetComponent<IWarmSource>();
        if(warmSource != null)
        {
            StopCoroutine(_warmUpCoroutine);
        }
    }
    private IEnumerator WarmUpPlayerCoroutine(int warmUpOverTime)
    {
        while(true)
        {
            CurrentHypoValue -= warmUpOverTime;
            yield return _delay;
        }
    }
    private IEnumerator FreezePlayerCoroutine()
    {
        while(true)
        {
            _freezeOverTime = Mathf.FloorToInt(difficultyCurve.Evaluate(_currentDay / 10f) * 100);
            CurrentHypoValue += _freezeOverTime;
            yield return _delay;
        }
    }
}
