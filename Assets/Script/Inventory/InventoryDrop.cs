using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDrop : MonoBehaviour, IDropHandler
{

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Drop!!");
        //Debug.Log(gameObject.name);
    }
}
