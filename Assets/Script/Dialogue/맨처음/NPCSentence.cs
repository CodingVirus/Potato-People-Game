using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    //public string[] sentences;
    //public GameObject MoveController;
    public GameObject Dialogsystem;

    private void OnMouseDown() 
    {
        PlayerMouseControll.instance.StopMove();
        Dialogsystem.GetComponent<DialogSystem>().UpdateDialog();

        //if(DialogueManager.instance.dialoguegroup.alpha == 0)
        //{
        //    DialogueManager.instance.Ondialogue(sentences);
        //}
    }
}
