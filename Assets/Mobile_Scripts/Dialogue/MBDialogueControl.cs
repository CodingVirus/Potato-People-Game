using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Conversation
{
    public MBDialogueSetting test;
    [TextArea(1, 3)]
    public string text;
    [Header("Events")]
    public UnityEvent eventSystem;
}

[RequireComponent(typeof(MBDialogueSetting))]
public class MBDialogueControl : MonoBehaviour
{
    public MBDialogueManager dialogueManager;
    public GameObject target;
    public List<Conversation> conversations;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Monologue"))
            {
                dialogueManager.copyConversation = conversations;
                dialogueManager.StartConversation();
            }
            else
            {
                dialogueManager.copyConversation = conversations;
                dialogueManager.testUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target) 
        {
            dialogueManager.testUI.SetActive(false);
        }
    }
}
