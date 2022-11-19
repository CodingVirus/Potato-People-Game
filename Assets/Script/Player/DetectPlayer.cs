using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //public GameObject ActiveButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            //ActiveButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            //ActiveButton.SetActive(false);
        }
    }
}
