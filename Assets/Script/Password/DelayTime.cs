using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTime : ClickableItem
{
    public GameObject pad;

    void OnMouseDown()
    {
        Invoke("OnDisplay", 0.5f);
    }

    public void OnDisplay()
    {
        //DigitalDisplay.pw();
        pad.GetComponent<DigitalDisplay>().Click();
        //DigitalDisplay.pw();
        PlayerMouseControll.instance.StopMove();
    }

}
