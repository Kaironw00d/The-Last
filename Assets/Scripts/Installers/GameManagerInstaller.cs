using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        GameManager gameManager = Container.InstantiatePrefabResourceForComponent<GameManager>("GameManager");

        Container
            .Bind<GameManager>()
            .FromInstance(gameManager)
            .AsSingle();
    }
}