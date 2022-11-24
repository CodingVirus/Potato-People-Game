using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 0.7f;
    float T_time = 1.1f;
    Color beta;
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInStart());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutStart());
    }

    IEnumerator FadeInStart()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        beta = Panel.color;
        while (beta.a < 1f)
        {
            time += Time.deltaTime / T_time;
            beta.a = Mathf.Lerp(0, 1, time);
            Panel.color = beta;
            yield return null;
        }
    }

    IEnumerator FadeOutStart()
    {
        time = 0f;
        while (beta.a > 0f)
        {
            time += Time.deltaTime / T_time;
            beta.a = Mathf.Lerp(1, 0, time);
            Panel.color = beta;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1,time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;

        yield return new WaitForSeconds(0.7f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}
