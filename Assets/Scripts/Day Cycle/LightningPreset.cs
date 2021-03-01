using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Lightning Preset", menuName = "Custom/Lightning Preset")]
public class LightningPreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
}
