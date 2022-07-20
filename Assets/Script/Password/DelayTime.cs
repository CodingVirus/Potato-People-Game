using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTime : ClickableItem
{

    void OnMouseDown()
    {
        Invoke("OnDisplay", 0.5f);
    }

    public void OnDisplay()
    {
        DigitalDisplay.pw();
    }

}
