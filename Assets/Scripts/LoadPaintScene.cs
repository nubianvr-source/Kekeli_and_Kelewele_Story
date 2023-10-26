using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPaintScene : MonoBehaviour
{
    public static LoadPaintScene Instance { set; get; }
    public PaintCanvasScriptableObject canvas;
   
    private void Awake()
    {
        Instance = this;
    }

    
    public void OpenPaintMenu()
    {
        Debug.Log("Going to new level");
        StaticVariables.canvas = canvas.paintCanvas;
        StaticVariables.colorList = canvas.colorList;
        SceneManager.LoadScene("TaptoPaintGame");
    }
}
