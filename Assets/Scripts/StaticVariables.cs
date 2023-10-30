using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static StaticVariables _instance;
    
    public PaintCanvasScriptableObject[] paintingList;
    private PaintCanvasScriptableObject _selectedPaintScreen;
    public PaintCanvasScriptableObject selectedPaintScreen => _selectedPaintScreen;

    public static GameObject canvas;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    
    public void PaintScreenSelected(int btnIndex)
    {
        print(btnIndex);
        _selectedPaintScreen = paintingList[btnIndex];
    }

}
