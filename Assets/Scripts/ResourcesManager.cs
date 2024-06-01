using UnityEngine;

public class ResourcesManager
{
    public static CardPrefabContainer GetCardPrefab()
    {
        return Resources.Load<CardPrefabContainer>(Configs.CARD_PREFAB_PATH);
    }

    public static CardSpriteContainer GetCardSprite(CardType cardType)
    {
        return Resources.Load<CardSpriteContainer>($"{Configs.CARD_SPRITE_PATH}/{cardType}");
    }
}
