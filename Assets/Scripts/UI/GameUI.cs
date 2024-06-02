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
    [SerializeField] private GameObject NoLevelPopup;
    
    private void Awake()
    {
        OnScoreChange(Core.Data.Score);
        OnLevelChange(Core.Data.CurrentLevel);

        if (Core.Resources.IsLevelLeft())
        {
            StartLevelPopup.ShowPopup();
        }
        else
        {
            ShowNoLevelLeft();
        }
        
        Core.Events.OnChangeScore += OnScoreChange;
        Core.Events.OnChangeLevel += OnLevelChange;

        Core.Events.OnFinishLevel += FinishLevelPopup.ShowPopup;
        Core.Events.OnCombo += ComboAlert.ShowAlert;

        Core.Events.OnNoLevelLeft += ShowNoLevelLeft;
    }

    private void OnDestroy()
    {
        Core.Events.OnChangeScore -= OnScoreChange;
        Core.Events.OnChangeLevel -= OnLevelChange;
        
        Core.Events.OnFinishLevel -= FinishLevelPopup.ShowPopup;
        Core.Events.OnCombo -= ComboAlert.ShowAlert;
        
        Core.Events.OnNoLevelLeft -= ShowNoLevelLeft;
    }

    private void OnScoreChange(int score)
    {
        ScoreText.SetText($"Score: {score}");
    }
    
    private void OnLevelChange(int level)
    {
        LevelText.SetText($"Level: {level + 1}");
    }

    private void ShowNoLevelLeft()
    {
        NoLevelPopup.SetActive(true);
    }
}
