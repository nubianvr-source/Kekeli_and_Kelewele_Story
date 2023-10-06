using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class TwoDimensionCardScript : MonoBehaviour, IPointerDownHandler
{
    private int _cardId;

    public Image cardBack;

    public CanvasGroup cardBackCanvasGroup;

    public CanvasGroup cardFrontCanvasGroup;

    private TwoDimensionCardScript self;

    private void Start()
    {
        self = this;
    }

    public int CardId()
    {
        return _cardId;
    }
    public void SetCard(int id, Sprite sprite)
    {
        _cardId = id;
        cardBack.sprite = sprite;
        cardBack.preserveAspect = true;
    }

    public void FlipOpen()
    {
        cardBackCanvasGroup.DOFade(1, 0.75F);
        cardFrontCanvasGroup.DOFade(0, 0.75F);
    }

    public void FlipClose()
    {
        cardBackCanvasGroup.DOFade(0, 0.75F);
        cardFrontCanvasGroup.DOFade(1, 0.75F);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.instance.gameIsPaused) return;
        if (!GameManager.instance.PickFull())
        {
            FlipOpen();
            GameManager.instance.AddCardToPickedList(self);
            GameManager.instance.AddCardTurned();
        }

        
    }
}
