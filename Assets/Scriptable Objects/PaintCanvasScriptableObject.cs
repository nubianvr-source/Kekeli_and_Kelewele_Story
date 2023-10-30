using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu (fileName = "PaintCanavas" , menuName = "ScriptableObjects/PaintCanvasScriptableObject")]
public class PaintCanvasScriptableObject : ScriptableObject
{
    public string Name;
    public GameObject paintCanvas;
    public Color[] colorList;
    public Sprite thumbnailImage;
}
