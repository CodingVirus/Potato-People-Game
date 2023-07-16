using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    public Transform destination;
    public Transform PlayerPosition;

    [SerializeField]
    public float T_limitMinX, T_limitMaxX, T_limitMinY, T_limitMaxY;

    public GameObject GetDesObj()
    {
        return destination.transform.parent.gameObject;
    }
    public Transform GetDestination()
    {
        return destination;
    }
}

