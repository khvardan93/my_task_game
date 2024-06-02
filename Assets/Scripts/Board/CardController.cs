using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer CardRenderer;
    private Sprite CardSprite;
    private Sprite BackSprite;

    public bool IsOpen
    {
        private set;
        get;
    }
    
    public void InitCard(CardType cardType)
    {
        CardRenderer = GetComponent<SpriteRenderer>();
        CardSprite = Core.Resources.GetCardSprite(cardType).GetSprite();
        BackSprite = Core.Resources.GetCardBackSprite(cardType).GetSprite();

        CardRenderer.sprite = BackSprite;
    }

    public void OpenCard()
    {
        if(IsOpen)
            return;

        IsOpen = true;
        
        CardRenderer.sprite = CardSprite;
        Invoke(nameof(CloseCard), Configs.CARD_OPEN_DURATION);
    }

    private void CloseCard()
    {
        IsOpen = false;
        CardRenderer.sprite = BackSprite;
    }
}
