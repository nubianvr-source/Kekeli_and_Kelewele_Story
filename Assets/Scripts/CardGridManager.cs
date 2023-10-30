using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGridManager : MonoBehaviour
{
    
    public GameObject cardsListParent;
    public LoadPaintScene cardPrefab;
    
    private void Start()
    {
        InstantiatePaintCards();
    }

    private void InstantiatePaintCards()
    {
        foreach (var i in StaticVariables._instance.paintingList)
        {
            var instancedObject = Instantiate(cardPrefab, cardsListParent.transform);
            instancedObject.cellThumbnailImage.sprite = i.thumbnailImage;
            instancedObject.cellPaintingName.text = i.name;
        }
    }

}
