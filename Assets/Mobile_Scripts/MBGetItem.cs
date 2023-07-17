using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MBGetItem : MonoBehaviour
{
    public Button interactionButton;
    public GameObject slider;
    public Slider sld;
    public bool buttonClick = false;
    public bool readyGetItem = true;
    private HasItem getItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            slider.SetActive(true);
            getItem = collision.GetComponent<HasItem>();
            interactionButton.interactable = true;
            if (readyGetItem == true)
            {
                interactionButton.onClick.AddListener(() => { getItem.GetItemTest(); });
                readyGetItem = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            slider.SetActive(false);
            interactionButton.interactable = false;
            interactionButton.onClick.RemoveAllListeners();
        }
    }

    public void buttonDown()
    {
        if ( interactionButton.interactable == true)
        {
            buttonClick = true;
        }  
    }

    public void buttonUp()
    {
        buttonClick = false;
        sld.value = 0f;
    }

    private void Update()
    {
        if (buttonClick)
        {
            sld.value += Time.deltaTime;
            if (sld.value >= 1f)
            {
                readyGetItem = true;
                interactionButton.interactable = false;
            }
        }
    }
}
