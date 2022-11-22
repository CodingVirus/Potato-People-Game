using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public GameObject hideFadeEffect;
    public bool hideStart = false;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(hideStart == true)
        {
            if(other.CompareTag("Hide"))
            {
                Invoke("HideEnter", 0.5f);
                Debug.Log("hide");
            }
        }
    }

    public void HideEnter()
    {
        PlayerMouseControll.instance.StopMove();
        hideFadeEffect.GetComponent<FadeIn>().Fade();
        Debug.Log("fade");
    }
}
