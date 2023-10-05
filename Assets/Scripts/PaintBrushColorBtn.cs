using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBrushColorBtn : MonoBehaviour
{
    public Image imageColor;

    public Image bandColor;

    public RectTransform btnRectTransform;

    public PaintManagerScript PaintManager { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnTapped()
    {
        Debug.Log(transform.GetSiblingIndex());
        PaintManager.SetBrushColor(transform.GetSiblingIndex());
    }

}
