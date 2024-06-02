using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private Dictionary<string, CardController> GameCards = new();

    private float ComboTimer;

    private ScoreData Score;

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
        Core.Data.DeleteSavedGame();

        Score.DoneCombos = 0;
        Score.DoneSteps = 0;
        Score.DestroyedCards = 0;
        Score.CardsCount = GameCards.Count;
    }

    public void StartSavedLevel()
    {
        if (Core.Data.TryGetSavedGame(out LevelData levelData))
        {
            Score = levelData.Score;
            Core.Events.OnStartSavedLevel?.Invoke(levelData.Cards);
            Core.Data.DeleteSavedGame();
        }
    }

    public void SaveGame()
    {
        if(GameCards.Count == 0)
            return;
        
        Core.Data.SaveGame(GameCards, Score);
    }
    
    private void ResetGame()
    {
        GameCards.Clear();
        ComboTimer = -1;

        Score = new();
    }

    public void RegisterCard(string cardName, CardController card)
    {
        GameCards.Add(cardName, card);
    }

    private void OnClickCard(string cardName)
    {
        if (GameCards.TryGetValue(cardName, out CardController card) && card.TryOpenCard())
        {
            Score.DoneSteps++;
            CheckMatches(card, cardName);
        }
    }

    private void CheckMatches(CardController card, string key)
    {
        int openCardCount = 0;
        bool isThereAnyMatch = false;
        
        foreach (var item in GameCards)
        {
            if(item.Value.CardState != CardState.Open)
                continue;

            openCardCount++;
            
            if (
                String.CompareOrdinal(item.Key, key) != 0 &&
                item.Value.CardType == card.CardType)
            {
                card.DestroyCard();
                item.Value.DestroyCard();

                Score.DestroyedCards += 2;
                Core.Events.OnMatch?.Invoke();
                isThereAnyMatch = true;
                CheckCombo();
            }
        }

        if (!isThereAnyMatch && openCardCount >= 2)
        {
            Core.Events.OnMismatch?.Invoke();
        }
        
        if (Score.DestroyedCards == Score.CardsCount)
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
            Score.DoneCombos++;
            
            Core.Events.OnCombo?.Invoke();
        }
    }
    
    private int GetLevelScore()
    {
        return (int)(Mathf.Clamp(Score.DestroyedCards / (float)Score.DoneSteps, 0.3f, 1) * 10) +
               Score.DoneCombos * Configs.REWARD_PER_COMBO;
    }
}