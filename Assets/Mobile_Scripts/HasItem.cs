using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasItem : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject computerWindow;
    private Inventory inven;

    private void Awake()
    {
        inven = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void TurnOnComputer()
    {
        computerWindow.SetActive(true);
    }

    public void GetItemTest()
    {
        if (computerWindow != null)
        {
            computerWindow.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            
            inven.AddItem(Item);
            Debug.Log("GetItem!");

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
