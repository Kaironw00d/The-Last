using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MushroomInstaller : MonoInstaller
{
    public List<Transform> spawnPoints;
    public Mushroom mushroomPrefab;
    public override void InstallBindings()
    {
        Container
            .Bind<List<Transform>>()
            .FromInstance(spawnPoints)
            .AsSingle();
        
        Container
            .Bind<Mushroom>()
            .FromInstance(mushroomPrefab)
            .AsSingle();
    }
}