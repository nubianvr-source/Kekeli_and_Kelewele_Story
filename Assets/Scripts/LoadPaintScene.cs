using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPaintScene : MonoBehaviour
{
    public Image cellThumbnailImage;
    public TMP_Text cellPaintingName;
   
    private void Awake()
    {

    }

    public void PaintingCellSelected()
    {
        var index = gameObject.transform.GetSiblingIndex();
        print(index);
        StaticVariables._instance.PaintScreenSelected(index);
        SceneManager.LoadScene("TaptoPaintGame");
    }

}
