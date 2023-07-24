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
    public GameObject testUI;

    public Image actorImage;

    [HideInInspector] public int count = 0;
    public float waitSecond = 0.08f;
    
    IEnumerator Test()
    {
        int i = 0;
        while (true)
        {
            if (i >= copyConversation[count].text.Length)
            {
                i = 0;
                break;
            }
                
            txt.text += copyConversation[count].text[i];
            i++;
            yield return new WaitForSeconds(waitSecond);
        }
        
        yield return true;
    }

    public void StartConversation()
    {
        DialogueStartEvents.Invoke();
        testUI.SetActive(false);
        ShowTriggerUI();
        
        if (copyConversation[count].test == null)
        {
            txt.color = Color.red;
            actorImage.sprite = copyConversation[count].test.img;
            ClearConversation();
            StartCoroutine("Test");
            copyConversation[count].eventSystem.Invoke();
        }
        else
        {
            actorImage.sprite = copyConversation[count].test.img;
            txt.color = copyConversation[count].test.textColor;
            ClearConversation();
            StartCoroutine("Test");
            copyConversation[count].eventSystem.Invoke();
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

        if (copyConversation[count].test == null)
        {
            txt.color = Color.red;
            actorImage.sprite = copyConversation[count].test.img;
            ClearConversation();
            StartCoroutine("Test");
            copyConversation[count].eventSystem.Invoke();
        }
        else
        {
            actorImage.sprite = copyConversation[count].test.img;
            txt.color = copyConversation[count].test.textColor;
            ClearConversation();
            StartCoroutine("Test");
            copyConversation[count].eventSystem.Invoke();
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