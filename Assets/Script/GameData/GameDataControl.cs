using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GameDataControl : MonoBehaviour
{
    public GameObject door3;
    public GameObject ply;
    public GameObject doctor;
    public GameObject endingDoctor;
    public GameObject cluey;
    public GameObject clueyDie;

    public bool b3Door = false;
    public bool b2Door = false;
    public bool b1Door = false;
    public bool prisonDoor = false;
    public bool officeDoor = false;
    public bool laboratoryA_Door = false;

    public bool clueyQuest = false;
    public bool CrematoriumPassword = false;

    public bool sokobanGame = false;
    public bool cirCuitGame = false;

    public bool gasMachineState = false;

    public bool monsterState = false;

    public bool UIstart = false;

    public GameObject ventLadderState;

    private void Update()
    {
        // for test
        // Delete after
        if (clueyQuest == true)
        {
            cluey.SetActive(false);
            clueyDie.SetActive(true);
        }
        else
        {
            cluey.SetActive(true);
            clueyDie.SetActive(false);
        }    
    }

    public void SetUIstartFalse()
    {
        UIstart = false;
    }
    public void ClueyQuestClear()
    {
        clueyQuest = true;
        cluey.SetActive(false);
        clueyDie.SetActive(true);
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
    public void SetMonsterState()
    {
        monsterState = true;
    }
    public bool ReturnB3Door()
    {
        return b3Door;
    }
    public bool ReturnPrisonDoor()
    {
        return prisonDoor;
    }
    public bool ReturnOfficeDoor()
    {
        return officeDoor;
    }
    public bool Returnb1Door()
    {
        return b1Door;
    }
    public bool ReturnCrematoriumPassword()
    {
        return CrematoriumPassword;
    }
    public bool ReturnGasState()
    {
        return gasMachineState;
    }
    public bool CheckVentState()
    {
        if (ventLadderState.activeSelf == true)
        {
            return true;
        }

        else
        {
            return false;
        }
        //return true;
    }
    public void LaboratoryALock()
    {
        laboratoryA_Door = false;
    }
    public void LaboratoryAUnLock()
    {
        laboratoryA_Door = true;
    }
    public bool ReturnMonsterState()
    {
        return monsterState;
    }

    void OnEnable()
    {
        Lua.RegisterFunction("ReturnClueyQuest", this, SymbolExtensions.GetMethodInfo(() => ReturnClueyQuest()));
        Lua.RegisterFunction("ReturnB3Door", this, SymbolExtensions.GetMethodInfo(() => ReturnB3Door()));
        Lua.RegisterFunction("ReturnPrisonDoor", this, SymbolExtensions.GetMethodInfo(() => ReturnPrisonDoor()));
        Lua.RegisterFunction("CheckVentState", this, SymbolExtensions.GetMethodInfo(() => CheckVentState()));
        Lua.RegisterFunction("ReturnOfficeDoor", this, SymbolExtensions.GetMethodInfo(() => ReturnOfficeDoor()));
        Lua.RegisterFunction("Returnb1Door", this, SymbolExtensions.GetMethodInfo(() => Returnb1Door()));
        Lua.RegisterFunction("ReturnGasState", this, SymbolExtensions.GetMethodInfo(() => ReturnGasState()));
        Lua.RegisterFunction("ReturnCrematoriumPassword", this, SymbolExtensions.GetMethodInfo(() => ReturnCrematoriumPassword()));
        Lua.RegisterFunction("ReturnMonsterState", this, SymbolExtensions.GetMethodInfo(() => ReturnMonsterState()));
        //Lua.RegisterFunction("AddOne", this, SymbolExtensions.GetMethodInfo(() => AddOne((double)0)));
    }

    void OnDisable()
    {
        Lua.UnregisterFunction("ReturnClueyQuest");
        Lua.UnregisterFunction("ReturnB3Door");
        Lua.UnregisterFunction("ReturnPrisonDoor");
        Lua.UnregisterFunction("CheckVentState");
        Lua.UnregisterFunction("ReturnOfficeDoor");
        Lua.UnregisterFunction("Returnb1Door");
        Lua.UnregisterFunction("ReturnGasState");
        Lua.UnregisterFunction("ReturnCrematoriumPassword");
        Lua.UnregisterFunction("ReturnMonsterState");
    }
}
