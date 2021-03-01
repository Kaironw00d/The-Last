using System;
using UnityEngine;
using Zenject;

public class DayCycleService : MonoBehaviour
{
    public event Action<int> OnDayChange;
    public float dayDuration;
    private int _currentDay;
    public int CurrentDay
    {
        get => _currentDay;
        set
        {
            _currentDay = value;
            OnDayChange?.Invoke(_currentDay);
        }
    }
    [SerializeField] private float _timeOfDay;
    private Light _directionalLight;
    private LightningPreset _preset;

    [Inject] private void Construct(Light directionalLight, LightningPreset preset)
    {
        _directionalLight = directionalLight;
        _preset = preset;
    }
    private void Start() => CurrentDay = 1;
    private void Update()
    {
        _timeOfDay += Time.deltaTime / dayDuration;
        if(_timeOfDay >= 1)
        {
            _timeOfDay -= 1;
            CurrentDay++;
        }
        UpdateLightning(_timeOfDay);
    }
    private void UpdateLightning(float timePercent)
    {
        RenderSettings.ambientLight = _preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = _preset.fogColor.Evaluate(timePercent);
        _directionalLight.color = _preset.directionalColor.Evaluate(timePercent);
        _directionalLight.transform.localRotation = Quaternion.Euler(new Vector3(timePercent * 360f - 90f, 170f, 0f));
    }
}
