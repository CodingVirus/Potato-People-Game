using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBFadeInOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDelay = 0.01f;
    IEnumerator FadeInOut()
    {
        // Fade In
        while (fadeImage.color.a <= 1.0f)
        {
            if (fadeImage.color.a >= 1.0f)
                break;
            fadeImage.color += new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(fadeDelay);
        }
        
        // Fade In ���Ŀ� �󸶿� �ð��� �帥�ڿ� Fade Out�� �� ������
        yield return new WaitForSeconds(0.5f);

        //Fade Out
        while (fadeImage.color.a >= 0f)
        {
            if (fadeImage.color.a <= 0f) 
                break;
            fadeImage.color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(fadeDelay);
        }
        gameObject.SetActive(false);
    }

    public void FadeStart()
    {
        gameObject.SetActive(true);
        StartCoroutine("FadeInOut");
    }
}
