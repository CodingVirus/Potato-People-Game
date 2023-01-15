using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;

    private void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "�ð� : " + Mathf.Round(LimitTime);

        if (LimitTime < 0f)
        {
            LimitTime = 0f;
        }
    }
}
