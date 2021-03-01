using UnityEngine;
using Zenject;

public class BootUI : MonoBehaviour
{
    private ProgressBar _loadingProgressBar;
    private UITweener _tweener;

    [Inject] private void Construct(ProgressBar loadingProgressBar, UITweener tweener)
    {
        _loadingProgressBar = loadingProgressBar;
        _tweener = tweener;
    }

    public void SetLoadingProgress(float value) => _loadingProgressBar.SetProgress(value);
    public void Hide() => _tweener.Disable();
}
