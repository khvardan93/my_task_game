using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer CardRenderer;
    
    public void SetType(CardType cardType)
    {
        CardRenderer = GetComponent<SpriteRenderer>();
        CardRenderer.sprite = ResourcesManager.GetCardSprite(cardType).GetSprite();
    }
}
