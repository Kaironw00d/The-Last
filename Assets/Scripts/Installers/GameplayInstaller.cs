using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public GameplayUI gameplayUI;
    public ProgressBar hungerProgressBar;
    public ProgressBar freezeProgressBar;
    public TMP_Text dayText;
    public PlayerHunger playerHunger;
    public PlayerHypothermia playerHypo;
    public override void InstallBindings()
    {
        Container
            .Bind<GameplayUI>()
            .FromInstance(gameplayUI)
            .AsSingle();
        Container
            .Bind<ProgressBar>()
            .WithId("Hunger")
            .FromInstance(hungerProgressBar)
            .AsCached();
        Container
            .Bind<ProgressBar>()
            .WithId("Freeze")
            .FromInstance(freezeProgressBar)
            .AsCached();
        Container
            .Bind<TMP_Text>()
            .WithId("Day")
            .FromInstance(dayText)
            .AsSingle();
        Container
            .Bind<PlayerHunger>()
            .FromInstance(playerHunger)
            .AsSingle();
        Container
            .Bind<PlayerHypothermia>()
            .FromInstance(playerHypo)
            .AsSingle();
    }
}