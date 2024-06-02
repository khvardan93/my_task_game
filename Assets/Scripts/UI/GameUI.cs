using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text LevelText;

    [Header("Popups")] 
    [SerializeField] private StartLevelPopup StartLevelPopup;
    [SerializeField] private FinishLevelPopup FinishLevelPopup;

    private void Awake()
    {
        OnScoreChange(Core.Data.Score);
        OnLevelChange(Core.Data.CurrentLevel);
        
        StartLevelPopup.ShowPopup();
        
        Core.Events.OnChangeScore += OnScoreChange;
        Core.Events.OnChangeLevel += OnLevelChange;

        Core.Events.OnFinishLevel += FinishLevelPopup.ShowPopup;
    }

    private void OnDestroy()
    {
        Core.Events.OnChangeScore -= OnScoreChange;
        Core.Events.OnChangeLevel -= OnLevelChange;
        
        Core.Events.OnFinishLevel -= FinishLevelPopup.ShowPopup;
    }

    private void OnScoreChange(int score)
    {
        ScoreText.SetText($"Score: {score}");
    }
    
    private void OnLevelChange(int level)
    {
        LevelText.SetText($"Level: {level + 1}");
    }
}
