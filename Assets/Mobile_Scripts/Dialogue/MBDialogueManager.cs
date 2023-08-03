using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MBDialogueManager : MonoBehaviour
{
    public Text txt;
    public List<Conversation> copyConversation;

    public UnityEvent DialogueStartEvents;
    public UnityEvent DialogueEndEvents;

    public GameObject conversationUI;
    public GameObject noticeUI;
    public GameObject noticeUI2;

    public Image actorImage;

    [HideInInspector] public int count = 0;
    public float waitSecond = 0.08f;
    
    IEnumerator Test()
    {
        int i = 0;
        while (true)
        {
            if (i >= copyConversation[count].text[0].Length)
            {
                i = 0;
                break;
            }
                
            txt.text += copyConversation[count].text[0][i];
            i++;
            yield return new WaitForSeconds(waitSecond);
        }
        
        yield return true;
    }

    private void DialogueStart()
    {
        actorImage.sprite = copyConversation[count].whoIsTalk.img;
        ClearConversation();
        StartCoroutine("Test");
        copyConversation[count].eventSystem.Invoke();
    }
    public void StartConversation()
    {
        DialogueStartEvents.Invoke();
        noticeUI.SetActive(false);
        ShowTriggerUI();
        
        if (copyConversation[count].whoIsTalk == null)
        {
            txt.color = Color.red;
            DialogueStart();
        }
        else
        {
            txt.color = copyConversation[count].whoIsTalk.textColor;
            DialogueStart();
        }
    }
    public void NextConversation()
    {
        count++;
        StopCoroutine("Test");

        if (count >= copyConversation.Count) 
        {
            count = 0;
            ExitConversation();
        }

        if (copyConversation[count].whoIsTalk == null)
        {
            txt.color = Color.red;
            DialogueStart();
        }
        else
        {
            txt.color = copyConversation[count].whoIsTalk.textColor;
            DialogueStart();
        }
    }
    private void EndConversation()
    {
        
    }
    private void CurrentConversation()
    {

    }
    
    private void ClearConversation()
    {
        //copyConversation.Clear();
        txt.text = string.Empty;
    }
    public void ExitConversation()
    {
        DialogueEndEvents.Invoke();
        ClearConversation();
        count = 0;
        conversationUI.SetActive(false);
    }
    private void ShowTriggerUI()
    {
        conversationUI.SetActive(true);
    }
}