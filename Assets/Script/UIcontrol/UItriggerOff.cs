using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItriggerOff : MonoBehaviour
{
    public GameObject stopTrigger;


    public void TriggerOff()
    {
        stopTrigger.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void TriggerOn()
    {
        stopTrigger.GetComponent<BoxCollider2D>().enabled = true;
    }
}
