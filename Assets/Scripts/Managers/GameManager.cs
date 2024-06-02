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
    
    private void OnClickCard(string cardName)
    {
        if (GameCards.TryGetValue(cardName, out CardController card))
        {
            card.OpenCard();
        }
    }
}
