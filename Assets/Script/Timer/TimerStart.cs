using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour
{
    public GameObject timerActive;
    private void OnMouseDown()
    {
        timerActive.SetActive(true);
    }
}
