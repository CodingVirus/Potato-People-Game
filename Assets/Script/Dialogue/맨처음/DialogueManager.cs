using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour, IPointerDownHandler
{

    public Text dialogueText;
    public GameObject nextText;
    public GameObject MoveController;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;

    private string currentSentence;

    private float typingSpeed = 0.03f;
    private bool istyping;

    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();
            //코루틴
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialoguegroup.alpha = 0;
            dialoguegroup.blocksRaycasts = false;
            Invoke("StartToMove", 0.5f);
        }
    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        //dialoueText == currentSentence 대사 한 줄 끝
        if(dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!istyping)
        NextSentence();
    }

    private void StartToMove()
    {
        PlayerMouseControll.instance.StartMove();
    }
}
