using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer CardRenderer;
    private Sprite CardSprite;
    private Sprite BackSprite;
    
    public void InitCard(CardType cardType)
    {
        CardRenderer = GetComponent<SpriteRenderer>();
        
        CardSprite = ResourcesManager.GetCardSprite(cardType).GetSprite();
        BackSprite = ResourcesManager.GetCardBackSprite(cardType).GetSprite();

        CardRenderer.sprite = BackSprite;
    }

    public void OpenCard()
    {
        CardRenderer.sprite = CardSprite;
    }
}
