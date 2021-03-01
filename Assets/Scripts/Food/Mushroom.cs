using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mushroom : MonoBehaviour, IFoodSource
{
    public event Action<Mushroom> OnInteruct;
    [SerializeField] private int _satiety = 15;
    public int Satiety => _satiety;

    public void Interuct() => OnInteruct?.Invoke(this);
}
