using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private Dictionary<string, CardController> GameCards = new();

    private int DestroyedCardCount = 0;
    private int CardOpenCount = 0;

    private float ComboTimer;
    private int ComboCount;

    public GameManager()
    {
        Core.Events.OnClickCard += OnClickCard;
    }

    ~GameManager()
    {
        Core.Events.OnClickCard -= OnClickCard;
    }

    public void StartLevel()
    {
        Core.Events.OnStartLevel?.Invoke();
    }
    
    private void ResetGame()
    {
        GameCards.Clear();
        DestroyedCardCount = 0;
        CardOpenCount = 0;
        ComboCount = 0;
        ComboTimer = -1;
    }

    public void RegisterCard(string cardName, CardController card)
    {
        GameCards.Add(cardName, card);
    }

    public void StartNextLevel()
    {
        StartLevel();
    }

    public void ReplayCurrentLevel()
    {
        StartLevel();
    }

    private void OnClickCard(string cardName)
    {
        if (GameCards.TryGetValue(cardName, out CardController card) && card.TryOpenCard())
        {
            CardOpenCount++;
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

                DestroyedCardCount += 2;

                CheckCombo();
            }
        }

        if (DestroyedCardCount == GameCards.Count)
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        int score = GetLevelScore();
        Core.Data.Score += score;
        Core.Data.CurrentLevel++;
        
        Core.Events.OnFinishLevel?.Invoke(GetLevelScore());
        ResetGame();
    }

    private void CheckCombo()
    {
        if (ComboTimer == -1 || Time.time - ComboTimer > Configs.COMBO_INTERVAL)
        {
            ComboTimer = Time.time;
        }
        else
        {
            ComboTimer = -1;
            ComboCount++;
            
            Core.Events.OnCombo?.Invoke();
        }
    }
    
    private int GetLevelScore()
    {
        return (int)(Mathf.Clamp(DestroyedCardCount / (float)CardOpenCount, 0.3f, 1) * 10) +
               ComboCount * Configs.REWARD_PER_COMBO;
    }
}
