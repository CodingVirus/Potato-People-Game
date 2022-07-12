using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ClickablePortal : MonoBehaviour
{
    public void OnMouseEnter() 
    {
        CursorController.instance.Portal_Click();  
    }

    public void OnMouseExit() 
    {
        CursorController.instance.Default();
    }
}
