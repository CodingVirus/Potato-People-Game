using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItriggerOff : MonoBehaviour
{
    public List<GameObject> triggerList = new List<GameObject>();
    public GameObject inven;

    public void TriggerOff()
    {
        inven.SetActive(false);
        //stopTrigger.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < triggerList.Count; i++)
        {
            if (triggerList[i].name == "Doctor")
            {
                triggerList[i].GetComponent<CapsuleCollider2D>().enabled = false;
            }

            else
                triggerList[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void TriggerOn()
    {
        inven.SetActive(true);
        //stopTrigger.GetComponent<BoxCollider2D>().enabled = true;
        for (int i = 0; i < triggerList.Count; i++)
        {
            if (triggerList[i].name == "Doctor")
            {
                triggerList[i].GetComponent<CapsuleCollider2D>().enabled = true;
            }

            else
                triggerList[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
