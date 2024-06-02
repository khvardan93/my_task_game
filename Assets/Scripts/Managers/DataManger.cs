using UnityEngine;

public class DataManger
{
    public int Score
    {
        get => PlayerPrefs.GetInt(Configs.SCORE_DATA_KEY);
        set => PlayerPrefs.SetInt(Configs.SCORE_DATA_KEY, value);
    }
    
    public int CurrentLevel
    {
        get => PlayerPrefs.GetInt(Configs.CURRENT_LEVEL_DATA_KEY);
        set => PlayerPrefs.SetInt(Configs.CURRENT_LEVEL_DATA_KEY, value);
    }
}
