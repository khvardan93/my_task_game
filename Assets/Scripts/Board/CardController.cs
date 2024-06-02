using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer CardRenderer;
    private Sprite CardSprite;
    private Sprite BackSprite;
    private Action<CardController> OnDestroyAction;

    public CardState CardState
    {
        private set;
        get;
    }

    public CardType CardType
    {
        private set;
        get;
    }
    
    public void InitCard(CardType cardType, Action<CardController> onDestroyAction)
    {
        gameObject.SetActive(true);
        
        OnDestroyAction = onDestroyAction;
        
        CardRenderer = GetComponent<SpriteRenderer>();
        CardSprite = Core.Resources.GetCardSprite(cardType).GetSprite();
        BackSprite = Core.Resources.GetCardBackSprite(cardType).GetSprite();

        CardRenderer.sprite = CardSprite;

        CardType = cardType;

        CardState = CardState.Preview;
        
        Invoke(nameof(CloseCard), Configs.CARD_PREVIEW_DURATION);
    }

    public bool TryOpenCard()
    {
        if(CardState != CardState.Closed)
            return false;

        CardState = CardState.Open;
        
        CardRenderer.sprite = CardSprite;
        Invoke(nameof(CloseCard), Configs.CARD_OPEN_DURATION);

        return true;
    }

    private void CloseCard()
    {
        CardState = CardState.Closed;
        CardRenderer.sprite = BackSprite;
    }

    public void DestroyCard()
    {
        CardState = CardState.Destroyed;
        CancelInvoke();
        Invoke(nameof(DisableCard), Configs.CARD_DESTROY_DURATION);
    }

    private void DisableCard()
    {
        OnDestroyAction?.Invoke(this);
        gameObject.SetActive(false);
    }
}
