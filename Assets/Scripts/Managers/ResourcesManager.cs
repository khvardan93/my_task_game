using UnityEngine;

public class ResourcesManager
{
    public CardPrefabContainer GetCardPrefab()
    {
        return Resources.Load<CardPrefabContainer>(Configs.CARD_PREFAB_PATH);
    }

    public CardSpriteContainer GetCardSprite(CardType cardType)
    {
        return Resources.Load<CardSpriteContainer>($"{Configs.CARD_SPRITE_PATH}/{cardType}");
    }
    
    public CardSpriteContainer GetCardBackSprite(CardType cardType)
    {
        return Resources.Load<CardSpriteContainer>(Configs.CARD_BACK_SPRITE_PATH);
    }

    public LevelContainer GetLevel(int index)
    {
        return Resources.Load<LevelContainer>($"{Configs.LEVELS_PATH}/Level_{index}");
    }
    
    public bool IsLevelLeft()
    {
        return GetLevel(Core.Data.CurrentLevel) != null;
    }
}
