using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    public string[] sentences;
    //public GameObject MoveController;

    private void OnMouseDown() 
    {
        PlayerMouseControll.instance.StopMove();

        if(DialogueManager.instance.dialoguegroup.alpha == 0)
        {
            DialogueManager.instance.Ondialogue(sentences);
        }
    }
}
