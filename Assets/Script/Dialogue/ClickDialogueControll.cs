using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PixelCrushers.DialogueSystem;
public class ClickDialogueControll : MonoBehaviour
{
    public GameObject gameData;
    private void OnMouseDown()
    {
        gameData.GetComponent<GameDataControl>().PlayerMouseControllOff();
        //this.GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    public void ColliderOff()
    {
        this.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
