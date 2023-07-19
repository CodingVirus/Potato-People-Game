using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MBDialogueManager : MonoBehaviour
{
    public Text txt;
    //public List<Conversation> con = new List<Conversation>();
    public UnityEvent events;
    public int count = 0;
    public GameObject conversationUI;
    
    IEnumerator Test()
    {
        yield return true;
    }

    public void StartConversation(List<Conversation> list)
    {
        ShowTriggerUI();
    }
    private void NextConversation()
    {
        //txt.text = con[0].text;

        count++;
    }
    private void EndConversation()
    {
        
    }
    private void CurrentConversation()
    {

    }
    
    private void ClearConversation()
    {

    }
    private void ExitConversation()
    {
        ClearConversation();
        count = 0;
        conversationUI.SetActive(false);
    }
    private void ShowTriggerUI()
    {
        conversationUI.SetActive(true);
    }
}