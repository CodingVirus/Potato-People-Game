using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBFadeInOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDelay = 0.01f;
    IEnumerator FadeIn()
    {
        while (fadeImage.color.a <= 1.0f)
        {
            if (fadeImage.color.a >= 1.0f)
                break;
            fadeImage.color += new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return new WaitForSeconds(fadeDelay);
        }
    }

    IEnumerator FadeOut()
    {
        while (fadeImage.color.a >= 0f)
        {
            if (fadeImage.color.a <= 0f)
                break;
            fadeImage.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return new WaitForSeconds(fadeDelay);
        }
        gameObject.SetActive(false);
    }

    IEnumerator FadeInOut()
    {
        // Fade In
        while (fadeImage.color.a <= 1.0f)
        {
            if (fadeImage.color.a >= 1.0f)
                break;
            fadeImage.color += new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return new WaitForSeconds(fadeDelay);
        }
        
        // Fade In 이후에 얼마에 시간이 흐른뒤에 Fade Out을 할 것인지
        yield return new WaitForSeconds(0.5f);

        //Fade Out
        while (fadeImage.color.a >= 0f)
        {
            if (fadeImage.color.a <= 0f) 
                break;
            fadeImage.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
            yield return new WaitForSeconds(fadeDelay);
        }
        gameObject.SetActive(false);
    }

    public void FadeStart()
    {
        gameObject.SetActive(true);
        StartCoroutine("FadeInOut");
    }

    public void FadeInStart() 
    {
        gameObject.SetActive(true);
        StartCoroutine("FadeIn");
    }

    public void FadeOutStart()
    {
        gameObject.SetActive(true);
        StartCoroutine("FadeOut");
    }
}
