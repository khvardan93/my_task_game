using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPrefabContainer", menuName = "ScriptableObjects/CardPrefabContainer")]
public class CardPrefabContainer : ScriptableObject
{
    [SerializeField] private CardController CardObject;

    public CardController GetCard()
    {
        return CardObject;
    }
}
