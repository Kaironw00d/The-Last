using UnityEngine;
using Zenject;

public class BootInstaller : MonoInstaller
{
    public BootState bootState;
    public BootUI bootUI;
    public ProgressBar loadingProgressBar;
    public override void InstallBindings()
    {
        /*Container
            .Bind<BootState>()
            .FromInstance(bootState)
            .AsSingle();*/
        Container
            .Bind<BootUI>()
            .FromInstance(bootUI)
            .AsSingle();
        Container
            .Bind<UITweener>()
            .FromInstance(bootUI.GetComponent<UITweener>())
            .AsCached();
        Container
            .Bind<ProgressBar>()
            .FromInstance(loadingProgressBar)
            .AsCached();
    }
}