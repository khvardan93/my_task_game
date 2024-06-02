using TMPro;
using UnityEngine;

public class StartLevelPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text LevelTextl;
    [SerializeField] private GameObject LoadItems;

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        LevelTextl.SetText($"Level: {Core.Data.CurrentLevel + 1}");
        
        LoadItems.SetActive(Core.Data.IsThereSavedGame());
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }
    
    public void OnStartLevel()
    {
        Core.Game.StartLevel();
        HidePopup();
    }
    
    public void OnStartSavedLevel()
    {
        Core.Game.StartSavedLevel();
        HidePopup();
    }
}
