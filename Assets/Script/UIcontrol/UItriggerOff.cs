using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItriggerOff : MonoBehaviour
{
    public GameObject stopTrigger;
    public List<GameObject> triggerList = new List<GameObject>();

    public void TriggerOff()
    {
        //stopTrigger.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < triggerList.Count; i++)
        {
            triggerList[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void TriggerOn()
    {
        //stopTrigger.GetComponent<BoxCollider2D>().enabled = true;
        for (int i = 0; i < triggerList.Count; i++)
        {
            triggerList[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
