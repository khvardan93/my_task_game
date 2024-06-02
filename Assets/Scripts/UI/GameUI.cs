using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text LevelText;

    [Header("Popups")] 
    [SerializeField] private StartLevelPopup StartLevelPopup;
    [SerializeField] private FinishLevelPopup FinishLevelPopup;
    [SerializeField] private ComboAlert ComboAlert;
    
    private void Awake()
    {
        OnScoreChange(Core.Data.Score);
        OnLevelChange(Core.Data.CurrentLevel);
        
        StartLevelPopup.ShowPopup();
        
        Core.Events.OnChangeScore += OnScoreChange;
        Core.Events.OnChangeLevel += OnLevelChange;

        Core.Events.OnFinishLevel += FinishLevelPopup.ShowPopup;
        Core.Events.OnCombo += ComboAlert.ShowAlert;
    }

    private void OnDestroy()
    {
        Core.Events.OnChangeScore -= OnScoreChange;
        Core.Events.OnChangeLevel -= OnLevelChange;
        
        Core.Events.OnFinishLevel -= FinishLevelPopup.ShowPopup;
        Core.Events.OnCombo -= ComboAlert.ShowAlert;
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
