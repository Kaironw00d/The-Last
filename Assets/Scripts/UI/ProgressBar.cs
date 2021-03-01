using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ProgressBar : MonoBehaviour
{
    [Range(0,1)] public float value;

    public Image mask;
    public Image fill;
    public Color color;

    public void SetProgress(float value)
    {
        mask.fillAmount = value;
    }
    public void ApplyValuesInEditorMode()
    {
        mask.fillAmount = value;
        fill.color = color;
    }

    private void OnValidate()
    {
        ApplyValuesInEditorMode();
    }

    #if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform);
    }
    #endif
}
