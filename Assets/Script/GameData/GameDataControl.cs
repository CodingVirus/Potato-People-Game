using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour
{
    public GameObject door3;
    public GameObject ply;

    public bool b3Door = false;
    public bool b2Door = false;
    public bool b1Door = false;
    public bool clueyQuest = false;

    public void ClueyQuestClear()
    {
        clueyQuest = true;
    }

    public void DoorOpen3F()
    {
        b3Door = true;
        door3.transform.position += new Vector3(-2, 0, 0);
    }
}
