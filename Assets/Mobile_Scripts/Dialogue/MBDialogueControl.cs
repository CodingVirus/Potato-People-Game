using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation
{
    public GameObject test;
    [TextArea(1, 3)]
    public string text;

}
public class MBDialogueControl : MonoBehaviour
{
    public MBDialogueManager dialogueManager;
    public List<Conversation> conversations = new List<Conversation>();
    public GameObject target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            dialogueManager.StartConversation(conversations);
        }
    }
}
