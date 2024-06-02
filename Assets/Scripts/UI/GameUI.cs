using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text LevelText;

    private void Awake()
    {
        Core.Events.OnChangeScore += OnScoreChange;
        Core.Events.OnChangeLevel += OnLevelChange;
    }

    private void OnDestroy()
    {
        Core.Events.OnChangeScore -= OnScoreChange;
        Core.Events.OnChangeLevel -= OnLevelChange;
    }

    private void OnScoreChange(int score)
    {
        ScoreText.SetText(score.ToString());
    }
    
    private void OnLevelChange(int level)
    {
        LevelText.SetText(level.ToString());
    }
}
