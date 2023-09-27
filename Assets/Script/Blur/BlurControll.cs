using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlurControll : MonoBehaviour
{
    public GameObject volume;
    public GameObject fade;
    public GameObject gameData;

    float time = 0f;
    float F_time = 2.5f;
    float count = 0f;
    public void BlurStart()
    {
        StartCoroutine(BlurIn());
    }
    IEnumerator BlurIn()
    {
        time = 0f;
        while (volume.GetComponent<Volume>().weight < 1f)
        {
            time += Time.deltaTime / F_time;
            volume.GetComponent<Volume>().weight = Mathf.Lerp(count, 1f, time);
            yield return null;
        }

        if (count > 1f)
        {
            fade.GetComponent<MBFadeInOut>().FadeStart();

            yield return new WaitForSeconds(1.5f);
            this.GetComponent<MobilePlayerMovement>().SceneTeleport();
            volume.GetComponent<Volume>().weight = 0f;

            yield break;
        }
        count += 0.4f;
        StartCoroutine(BlurOut());
    }

    IEnumerator BlurOut()
    {
        time = 0f;
        while (volume.GetComponent<Volume>().weight > count)
        {
            time += Time.deltaTime / F_time;
            volume.GetComponent<Volume>().weight = Mathf.Lerp(1f, count, time);

            yield return null;
        }

        StartCoroutine(BlurIn());
    }
}
