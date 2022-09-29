using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GameDataControl : MonoBehaviour
{
    public GameObject door3;
    public GameObject ply;

    public bool b3Door = false;
    public bool b2Door = false;
    public bool b1Door = false;
    public bool clueyQuest = false;
    public bool sokobanGame = false;

    public void ClueyQuestClear()
    {
        clueyQuest = true;
    }
    public bool ReturnClueyQuest()
    {
        return clueyQuest;
    }

    public void DoorOpen3F()
    {
        b3Door = true;
        door3.transform.position += new Vector3(-2, 0, 0);
    }
    public bool ReturnB3Door()
    {
        return b3Door;
    }

    void OnEnable()
    {
        Lua.RegisterFunction("ReturnClueyQuest", this, SymbolExtensions.GetMethodInfo(() => ReturnClueyQuest()));
        Lua.RegisterFunction("ReturnB3Door", this, SymbolExtensions.GetMethodInfo(() => ReturnB3Door()));
        //Lua.RegisterFunction("AddOne", this, SymbolExtensions.GetMethodInfo(() => AddOne((double)0)));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("ReturnClueyQuest");
        Lua.UnregisterFunction("ReturnB3Door");
    }
}
