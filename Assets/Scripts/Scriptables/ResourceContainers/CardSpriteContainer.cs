using UnityEngine;

[CreateAssetMenu(fileName = "CardSpriteContainer", menuName = "ScriptableObjects/CardSpriteContainer")]
public class CardSpriteContainer : ScriptableObject
{
    [SerializeField] private Sprite CardSprite;

    public Sprite GetSprite()
    {
        return CardSprite;
    }
}
