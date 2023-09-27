using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBHide : MonoBehaviour
{
    [SerializeField] private MBFadeInOut fade;
    [SerializeField] private Button outButton;
    public void HidePlayer()
    {
        fade.FadeInStart();
        MBGameManger.instance.GetPlayerObj().SetActive(false);
        outButton.gameObject.SetActive(true);
    }

    public void HideOut()
    {
        outButton.gameObject.SetActive(false);
        fade.FadeOutStart();
        MBGameManger.instance.GetPlayerObj().SetActive(true);
    }
}
