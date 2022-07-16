using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    public string[] sentences;
    public GameObject MoveController;

    private void OnMouseDown() 
    {
        MoveController.GetComponent<PlayerMouseControll>().playerMove = false;

        if(DialogueManager.instance.dialoguegroup.alpha == 0)
        {
            DialogueManager.instance.Ondialogue(sentences);
        }
    }
}
