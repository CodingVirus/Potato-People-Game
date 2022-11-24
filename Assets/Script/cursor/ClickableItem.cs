using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ClickableItem : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void OnMouseEnter() 
    {
        CursorController.instance.Item_Click();  
    }

    public void OnMouseExit() 
    {
        CursorController.instance.Default();
    }
}
