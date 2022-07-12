using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Clickable : MonoBehaviour
{
    public void OnMouseEnter() 
    {
        CursorController.instance.Clickable();  
    }

    public void OnMouseExit() 
    {
        CursorController.instance.Default();
    }
}
