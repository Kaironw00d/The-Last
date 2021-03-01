using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public MainMenuUI mainMenuUI;
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;
    public Animation cameraAnimation;
    public override void InstallBindings()
    {
        Container
            .Bind<MainMenuUI>()
            .FromInstance(mainMenuUI)
            .AsSingle();
        Container
            .Bind<Button>()
            .WithId("Play")
            .FromInstance(playButton)
            .AsCached();
        Container
            .Bind<Button>()
            .WithId("Settings")
            .FromInstance(settingsButton)
            .AsCached();
        Container
            .Bind<Button>()
            .WithId("Quit")
            .FromInstance(quitButton)
            .AsCached();
        Container
            .Bind<UITweener>()
            .WithId("MainMenu_Tweener")
            .FromInstance(mainMenuUI.GetComponent<UITweener>())
            .AsCached();
        Container
            .Bind<Animation>()
            .FromInstance(cameraAnimation)
            .AsSingle();
    }
}