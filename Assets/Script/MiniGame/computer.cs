using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class computer : ClickableItem
{
    public GameObject monitor;

    private void OnMouseDown() 
    {
        monitor.SetActive(true);
    }

    public void MonitorClose()
    {
        monitor.SetActive(false);
    }
}
