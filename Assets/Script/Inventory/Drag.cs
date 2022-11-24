using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultPos;
    public Vector2 testPos;
    GameObject parentSlot;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        defaultPos = this.transform.position;
        parentSlot = this.transform.parent.gameObject;
        //Debug.Log("Lo1!!!");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;

        //Debug.Log(parentSlot.name);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(eventData.position - defaultPos);
        testPos = eventData.position - defaultPos;
        if (Mathf.Sqrt(Mathf.Pow(testPos.x, 2) + Mathf.Pow(testPos.y, 2)) > 108f)
        {
            parentSlot.GetComponent<UseItem>().ThrowItem(this.transform.name);
        }
        
        else
        {
            this.transform.position = defaultPos;
        }
    }
}
