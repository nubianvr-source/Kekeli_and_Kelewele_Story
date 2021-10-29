using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraBackgroundController : MonoBehaviour
{
    private Camera _mainCamera;
 
    void Update()
    {
    
    }

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }

    public void ColorChangeGray()
    {
        _mainCamera.DOColor(new Color(165f / 255f, 165f / 255f, 165f / 255f, 255f / 255f), 1.5f);
    }

    public void ColorChangeWhite()
    {
        _mainCamera.DOColor(Color.white, 1.5f);

    }
     public void ColorChangeBrown()
     {
         _mainCamera.DOColor(new Color(63f / 255f, 54f / 255f, 52f / 255f), 1.0f);

     }
     public void ColorChangeLightBrown()
     {
         _mainCamera.DOColor(new Color(219f / 255f, 194f / 255f, 190f / 255f), 1.0f);
     }

     public void ColorChangeCream()
     {
         _mainCamera.DOColor(new Color(253f / 255f, 246f / 255f, 239f / 255f), 1.0f);
     }

     public void ColorChangeDullPink()
     {
         _mainCamera.DOColor(new Color(127f / 255f, 94f / 255f, 106f / 255f), 1.0f);
     }

     public void ColorChangeBlack()
     {
         _mainCamera.DOColor(Color.black, 1.0f);
     }
}
