using System;
using System.Collections.Generic;

public class GameManager
{
    private Dictionary<string, CardController> GameCards = new();

    public GameManager()
    {
        Core.Events.OnClickCard += OnClickCard;
    }

    ~GameManager()
    {
        Core.Events.OnClickCard -= OnClickCard;
    }

    public void RegisterCard(string cardName, CardController card)
    {
        GameCards.Add(cardName, card);
    }

    public void StartNextLevel()
    {
        
    }

    public void ReplayCurrentLevel()
    {
        
    }

    private void OnClickCard(string cardName)
    {
        if (GameCards.TryGetValue(cardName, out CardController card) && card.TryOpenCard())
        {
            CheckMatches(card, cardName);
        }
    }

    private void CheckMatches(CardController card, string key)
    {
        foreach (var item in GameCards)
        {
            if (
                String.CompareOrdinal(item.Key, key) != 0 &&
                item.Value.CardState == CardState.Open &&
                item.Value.CardType == card.CardType)
            {
                card.DestroyCard();
                item.Value.DestroyCard();
            }
        }
    }
}
