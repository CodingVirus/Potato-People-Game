using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    Color test;

    private void Start()
    {
        test = this.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjToPush"))
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("HI");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjToPush"))
        {
            this.GetComponent<SpriteRenderer>().color = test;
        }
    }

    public void End()
    {
        SceneManager.LoadScene("BuwonScene");
    }
}
