using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct CardData
{
    public Vector2Int Pos;
    public CardType Type;
}

[System.Serializable]
public struct ScoreData
{
    public int DestroyedCards;
    public int DoneSteps;
    public int DoneCombos;
    public int CardsCount;
}

[System.Serializable]
public struct LevelData
{
    public ScoreData Score;
    public List<CardData> Cards;
}

public class DataManger
{
    private int CachedScore = -1;
    public int Score
    {
        get
        {
            if (CachedScore == -1)
                CachedScore = PlayerPrefs.GetInt(Configs.SCORE_DATA_KEY);

            return CachedScore;
        }
        
        set
        {
            PlayerPrefs.SetInt(Configs.SCORE_DATA_KEY, value);
            CachedScore = value;
            Core.Events.OnChangeScore?.Invoke(value);
        }
    }
    
    private int CachedLevel = -1;
    public int CurrentLevel
    {
        get
        {
            if (CachedLevel == -1)
                CachedLevel = PlayerPrefs.GetInt(Configs.CURRENT_LEVEL_DATA_KEY);

            return CachedLevel;
        }
        
        set
        {
            PlayerPrefs.SetInt(Configs.CURRENT_LEVEL_DATA_KEY, value);
            CachedLevel = value;
            Core.Events.OnChangeLevel?.Invoke(value);
        }
    }

    public void SaveGame(Dictionary<string, CardController> gameCards, ScoreData score)
    {
        List<CardData> levelCards = new();

        foreach (var card in gameCards)
        {
            if(card.Value.CardState == CardState.Destroyed)
                continue;
            
            levelCards.Add(new ()
            {
                Pos = card.Value.CardPosition,
                Type = card.Value.CardType
            });
        }

        LevelData levelData = new()
        {
            Score = score,
            Cards = levelCards
        };
        
        PlayerPrefs.SetString(Configs.SAVED_LEVEL_DATA, JsonUtility.ToJson(levelData));
    }

    public bool IsThereSavedGame()
    {
        return PlayerPrefs.HasKey(Configs.SAVED_LEVEL_DATA);
    }
    
    public void DeleteSavedGame()
    {
        PlayerPrefs.DeleteKey(Configs.SAVED_LEVEL_DATA);
    }
    
    public bool TryGetSavedGame(out LevelData levelData)
    {
        if (!IsThereSavedGame())
        {
            levelData = new LevelData();
            return false;
        }

        levelData = JsonUtility.FromJson<LevelData>(PlayerPrefs.GetString(Configs.SAVED_LEVEL_DATA));
        return true;
    }
}
