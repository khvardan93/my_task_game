using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAlert : MonoBehaviour
{
    public void ShowAlert()
    {
        gameObject.SetActive(true);
        Invoke(nameof(HideAlert), Configs.COMBO_ANIM_DURATION);
    }

    public void HideAlert()
    {
        gameObject.SetActive(false);
    }
}
