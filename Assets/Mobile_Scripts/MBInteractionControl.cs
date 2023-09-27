using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MBInteractionControl : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    [SerializeField] private GameObject computerWindow;
    [SerializeField] private GameObject hide;
    private Inventory inven;

    private void Start()
    {
        inven = MBGameManger.instance.GetPlayerObj().GetComponent<Inventory>();
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
        else if (hide != null)
        {
            GetComponent<MBHide>().HidePlayer();
        }
        else
        {            
            inven.AddItem(Item);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
