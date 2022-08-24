using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{

    public Image btnImage;
    public int rateValue;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;
    public void ButtonAddedToRate()
    {
        btnImage.sprite = selectedSprite;
    }

    public void ButtonClear()
    {
        btnImage.sprite = unselectedSprite;
    }

}
