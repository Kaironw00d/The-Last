using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Campfire : MonoBehaviour, IWarmSource
{
    [SerializeField] private int _warmUpOverTime = 3;
    public int WarmUpOverTime => _warmUpOverTime;
}
