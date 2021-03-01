using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseInstaller : MonoInstaller
{
    public PauseUI pauseUI;
    public Button restartButton;
    public Button menuButton;
    public Button quitButton;
    public Button resumeButton;
    public override void InstallBindings()
    {
        Container
            .Bind<PauseUI>()
            .FromInstance(pauseUI)
            .AsSingle();
        Container
            .Bind<Button>()
            .WithId("Pause_Restart")
            .FromInstance(restartButton)
            .AsCached();
        Container
            .Bind<Button>()
            .WithId("Pause_Menu")
            .FromInstance(menuButton)
            .AsCached();
        Container
            .Bind<Button>()
            .WithId("Pause_Quit")
            .FromInstance(quitButton)
            .AsCached();
        Container
            .Bind<Button>()
            .WithId("Pause_Resume")
            .FromInstance(resumeButton)
            .AsCached();
        Container
            .Bind<UITweener>()
            .WithId("Pause_Tweener")
            .FromInstance(pauseUI.GetComponent<UITweener>())
            .AsCached();
    }
}