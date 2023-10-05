using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int _cardId;
    
    public SpriteRenderer cardFront;
    
    public Animator animator;
    
    private static readonly int FlippedCard = Animator.StringToHash("FlippedCard");

    public int CardId()
    {
        return _cardId;
    }
    public void SetCard(int id, Sprite sprite)
    {
        _cardId = id;
        cardFront.sprite = sprite;
        //cardFront.transform.localScale.Set(0.8f,0.8f,1f);
    }

    public void FlipOpen(bool flipped)
    {
        animator.SetBool(FlippedCard, flipped);
    }

    public void FlipClose(bool flipped)
    {
        animator.SetBool(FlippedCard, flipped);
    }
}

