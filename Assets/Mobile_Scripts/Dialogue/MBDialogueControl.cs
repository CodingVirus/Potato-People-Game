using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class Conversation
{
    public MBDialogueSetting whoIsTalk = null;

    public bool isOption = false;
    [TextArea(1, 3)] public List<string> text;
    [Header("Events")] public UnityEvent eventSystem;
}

[RequireComponent(typeof(MBDialogueSetting))]
public class MBDialogueControl : MonoBehaviour
{
    public MBDialogueManager dialogueManager;
    public GameObject target;
    public List<Conversation> conversations;

    public bool isTest = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTest) 
            {
                dialogueManager.noticeUI2.SetActive(false);
                dialogueManager.StartConversation();
                isTest = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Monologue"))
            {
                dialogueManager.copyConversation = conversations;
                dialogueManager.StartConversation();
            }
            else if (this.gameObject.layer == LayerMask.NameToLayer("TestConversation"))
            {
                isTest = true;
                dialogueManager.noticeUI2.SetActive(true);
                dialogueManager.copyConversation = conversations;
            }
            else
            {
                dialogueManager.copyConversation = conversations;
                dialogueManager.noticeUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target) 
        {
            isTest = false;
            dialogueManager.noticeUI.SetActive(false);
        }
    }
}
