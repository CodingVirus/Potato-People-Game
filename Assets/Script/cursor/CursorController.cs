using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    public Texture2D defaultCursor, clickItem, clickPortal, clickDialogue, clickHide;

    public static CursorController instance;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        Default();
    }

    public void Item_Click()
    {
        Vector2 hotspot = new Vector2(clickItem.width / 2, clickItem.height / 2);
        Cursor.SetCursor(clickItem, hotspot, CursorMode.Auto);
    }

    public void Default()
    {
        Vector2 hotspot = new Vector2(defaultCursor.width / 2, defaultCursor.height / 2);
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public void Portal_Click()
    {
        Vector2 hotspot = new Vector2(clickPortal.width / 2, clickPortal.height / 2);
        Cursor.SetCursor(clickPortal, hotspot, CursorMode.Auto);
    }

    public void Dialogue_Click()
    {
        Vector2 hotspot = new Vector2(clickDialogue.width / 2, clickDialogue.height / 2);
        Cursor.SetCursor(clickDialogue, hotspot, CursorMode.Auto);
    }

    public void Hide_Click()
    {
        Vector2 hotspot = new Vector2(clickHide.width / 2, clickHide.height / 2);
        Cursor.SetCursor(clickHide, hotspot, CursorMode.Auto);
    }

}


