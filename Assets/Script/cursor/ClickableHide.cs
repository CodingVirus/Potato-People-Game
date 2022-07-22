using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ClickableHide : MonoBehaviour
{
    public void OnMouseEnter() 
    {
        CursorController.instance.Hide_Click();  
    }

    public void OnMouseExit() 
    {
        CursorController.instance.Default();
    }
}
