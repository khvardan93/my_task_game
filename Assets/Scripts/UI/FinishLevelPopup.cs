using TMPro;
using UnityEngine;

public class FinishLevelPopup : MonoBehaviour
{
    [SerializeField] private GameObject Popup;
    [SerializeField] private TMP_Text TitleText;
    [SerializeField] private TMP_Text RewardText;

    public void ShowPopup(int score)
    {
        TitleText.SetText($"Level {Core.Data.CurrentLevel} is finished!");
        RewardText.SetText($"Level score: {score}");

        gameObject.SetActive(true);
        Popup.SetActive(false);
        Invoke(nameof(EnablePopup), Configs.FINISH_POPUP_OPEN_DELAY);
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }

    public void StartNextLevel()
    {
        Core.Game.StartLevel();
        HidePopup();
    }

    private void EnablePopup()
    {
        Popup.SetActive(true);
    }
}