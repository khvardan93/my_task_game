using UnityEngine;

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
}
