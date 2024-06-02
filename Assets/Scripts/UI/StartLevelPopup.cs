using TMPro;
using UnityEngine;

public class StartLevelPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text LevelTextl;

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        LevelTextl.SetText($"Level: {Core.Data.CurrentLevel + 1}");
    }

    public void HidePopup()
    {
        gameObject.SetActive(false);
    }
    
    public void OnStartLevel()
    {
        Core.Events.OnStartLevel?.Invoke();
        HidePopup();
    }
}
