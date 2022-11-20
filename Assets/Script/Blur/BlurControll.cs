using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlurControll : MonoBehaviour
{
    public GameObject test;
    public GameObject fade;
    float time = 0f;
    float F_time = 2.5f;
    float count = 0f;
    private void Start()
    {
        //weight = test.GetComponent<Volume>().weight;
    }
    public void test2()
    {
        StartCoroutine(test1());

    }

    private void Update()
    {
        //Debug.Log(test.GetComponent<Volume>().weight);
        //Debug.Log(time);
        //Debug.Log(count);
    }

    IEnumerator test1()
    {
        time = 0f;
        while (test.GetComponent<Volume>().weight < 1f)
        {
            time += Time.deltaTime / F_time;
            test.GetComponent<Volume>().weight = Mathf.Lerp(count, 1f, time);
            yield return null;
        }

        if (count > 1f)
        {
            fade.GetComponent<FadeScript>().FadeIn();

            yield return new WaitForSeconds(2f);
            this.GetComponent<PlayerTeleport>().SceneTeleport();
            test.GetComponent<Volume>().weight = 0f;

            yield return new WaitForSeconds(2f);
            fade.GetComponent<FadeScript>().FadeOut();

            yield break;
        }
        count += 0.4f;
        StartCoroutine(test3());
    }

    IEnumerator test3()
    {
        time = 0f;
        while (test.GetComponent<Volume>().weight > count)
        {
            time += Time.deltaTime / F_time;
            test.GetComponent<Volume>().weight = Mathf.Lerp(1f, count, time);

            yield return null;
        }

        StartCoroutine(test1());
    }
}
