using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPrefabContainer", menuName = "ScriptableObjects/CardPrefabContainer")]
public class CardPrefabContainer : ScriptableObject
{
    [SerializeField] private CardController CardObject;
    [SerializeField] private Vector2 SpriteSize;

    public CardController GetCard()
    {
        return CardObject;
    }

    public Vector2 GetSpriteSize()
    {
        return SpriteSize;
    }
}
