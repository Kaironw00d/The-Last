using UnityEngine;
using Zenject;

public class DayCycleServiceInstaller : MonoInstaller
{
    public Light directionalLight;
    public LightningPreset preset;

    public override void InstallBindings()
    {
        Container
            .Bind<Light>()
            .FromInstance(directionalLight)
            .AsSingle();
        
        Container
            .Bind<LightningPreset>()
            .FromInstance(preset)
            .AsSingle();
    }
}