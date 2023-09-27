using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDrop : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        Drag drag = dropObj.GetComponent<Drag>();
        drag.parentAfterDrag = transform;
    }
}
