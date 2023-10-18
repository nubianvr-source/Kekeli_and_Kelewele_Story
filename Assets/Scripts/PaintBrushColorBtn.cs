using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PaintBrushColorBtn : MonoBehaviour
{
    //public Image imageColor;

    public Image bandColor;

    public RectTransform btnRectTransform;
    
    public PaintManagerScript PaintManager { get; set; }
    
    public void OnBtnTapped()
    {
        Debug.Log(transform.GetSiblingIndex());
        PaintManager.SetBrushColor(transform.GetSiblingIndex());
    }

}
