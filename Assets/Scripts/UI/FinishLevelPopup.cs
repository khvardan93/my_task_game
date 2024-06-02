using TMPro;
using UnityEngine;

public class FinishLevelPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text TitleText;
    [SerializeField] private TMP_Text RewardText;
    
    public void ShowPopup(int score)
    {
        TitleText.SetText($"Level {Core.Data.CurrentLevel + 1} is finished!");
        RewardText.SetText($"Level score: {score}");
        
        gameObject.SetActive(true);
    }
    
    public void HidePopup()
    {
        gameObject.SetActive(false);
    }

    public void StartNextLevel()
    {
        Core.Game.StartNextLevel();
        HidePopup();
    }
    
    public void ReplayCurrentLevel()
    {
        Core.Game.ReplayCurrentLevel();
        HidePopup();
    }
}