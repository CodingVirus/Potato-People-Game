using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Rendering.Universal;

public class FadeIn : MonoBehaviour
{
    public Image Black;
    public GameObject player;
    float time = 0f;
    float F_time = 0.5f;

    public Light2D playerLight;
    public GameObject test;

    public void Fade()
    {
        StartCoroutine(FadeStart());
    }

    public void HideEnd()
    {
        StartCoroutine(FadeEnd());
        //Black.gameObject.SetActive(false);
        player.GetComponent<PlayerHide>().hideStart = false;
        Invoke("HideMove", 0.4f);
    }

    private void HideMove()
    {
        player.GetComponent<PlayerMouseControll>().target = player.transform.position;
        PlayerMouseControll.instance.StartMove();
    }

    IEnumerator FadeStart()
    {
        playerLight = player.GetComponent<LightControll>().global;

        test = player.GetComponent<LightControll>().allB3;

        test.SetActive(false);
        player.SetActive(false);
        Black.gameObject.SetActive(true);
        time = 0f;
        while (playerLight.intensity > 0f)
        {
            time += Time.deltaTime / F_time;
            playerLight.intensity = Mathf.Lerp(1, 0f, time);
            //Black.color = alpha;
            yield return null;
        }
        //Black.gameObject.SetActive(true);
        //time = 0f;
        //Color alpha = Black.color;
        //while (alpha.a < 1f)
        //{
        //    time += Time.deltaTime / F_time;
        //    alpha.a = Mathf.Lerp(0,1,time);
        //    Black.color = alpha;
        //    yield return null;
        //}
    }

    IEnumerator FadeEnd()
    {
        playerLight = player.GetComponent<LightControll>().global;
        player.SetActive(true);
        Black.gameObject.SetActive(false);
        time = 0f;
        while (playerLight.intensity < 1.0f)
        {
            time += Time.deltaTime / F_time;
            playerLight.intensity = Mathf.Lerp(0, 1, time);
            //Black.color = alpha;
            yield return null;
        }
        //Black.gameObject.SetActive(true);
        //time = 0f;
        //Color alpha = Black.color;
        //while (alpha.a > 0f)
        //{
        //    time += Time.deltaTime / F_time;
        //    alpha.a = Mathf.Lerp(1, 0, time);
        //    Black.color = alpha;
        //    yield return null;
        //}
        //Black.gameObject.SetActive(false);
    }
}
