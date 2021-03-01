using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public new Transform transform;
    public PlayerInput input;
    public NavMeshAgent agent;
    public Animator animator;
    public DayCycleService dayCycleService;

    public override void InstallBindings()
    {
        Container
            .Bind<Transform>()
            .WithId("PlayerTransform")
            .FromInstance(transform)
            .AsSingle();
        Container
            .Bind<PlayerInput>()
            .FromInstance(input)
            .AsSingle();
        Container
            .Bind<NavMeshAgent>()
            .FromInstance(agent)
            .AsSingle();
        Container
            .Bind<Animator>()
            .FromInstance(animator)
            .AsSingle();
        Container
            .Bind<DayCycleService>()
            .FromInstance(dayCycleService)
            .AsSingle();
        
    }
}