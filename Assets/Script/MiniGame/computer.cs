using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class computer : ClickableItem
{
    public GameObject monitor;
    public GameObject ply;

    private void OnMouseDown() 
    {
        monitor.SetActive(true);
        ply.GetComponent<PlayerMouseControll>().StopMove();
        this.GetComponent<UItriggerOff>().TriggerOff();
    }

    public void MonitorClose()
    {
        monitor.SetActive(false);
    }
}
