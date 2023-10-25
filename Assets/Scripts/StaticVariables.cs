using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static StaticVariables Instance { set; get; }

    [HideInInspector]
    public static GameObject canvas;

    [HideInInspector]
    public static Color[] colorList;

    private void Awake()
    {

        Instance = this;
        Debug.Log("Here");
    }
    
}
