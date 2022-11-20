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
    public GameObject test2;

    public void Fade()
    {
        StartCoroutine(FadeStart());
    }

    public void BasicFade()
    {
        StartCoroutine(BasicFadeStart());
    }

    public void HideEnd()
    {
        StartCoroutine(FadeEnd());
        //Black.gameObject.SetActive(false);
        player.GetComponent<PlayerHide>().hideStart = false;
        Invoke("HideMove", 0.4f);
    }

    public void OutButton()
    {
        Black.gameObject.SetActive(true);
    }

    public void PlayerOut()
    {
        player.SetActive(true);
    }

    private void HideMove()
    {
        player.GetComponent<PlayerMouseControll>().target = player.transform.position;
        PlayerMouseControll.instance.StartMove();
    }
    IEnumerator BasicFadeStart()
    {
        playerLight = player.GetComponent<LightControll>().global;
        time = 0f;
        while (playerLight.intensity > 0f)
        {
            time += Time.deltaTime / F_time;
            playerLight.intensity = Mathf.Lerp(0.3f, 0f, time);
            yield return null;
        }
    }
    IEnumerator FadeStart()
    {
        playerLight = player.GetComponent<LightControll>().global;
        test2 = player.GetComponent<LightControll>().allB2;
        test = player.GetComponent<LightControll>().allB3;

        test2.SetActive(false);
        test.SetActive(false);
        player.SetActive(false);
        Invoke("OutButton", 1.3f);
        time = 0f;
        while (playerLight.intensity > 0f)
        {
            time += Time.deltaTime / F_time;
            playerLight.intensity = Mathf.Lerp(0.3f, 0f, time);
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
        test = player.GetComponent<LightControll>().allB3;
        test2 = player.GetComponent<LightControll>().allB2;

        test2.SetActive(true);
        test.SetActive(true);
        player.SetActive(true);
        //Invoke("PlayerOut", 0.5f);
        Black.gameObject.SetActive(false);
        time = 0f;
        while (playerLight.intensity < 0.3f)
        {
            time += Time.deltaTime / F_time;
            playerLight.intensity = Mathf.Lerp(0f, 0.3f, time);
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
