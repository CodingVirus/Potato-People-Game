using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUp : MonoBehaviour
{
    private bool active = false;
    public GameObject slotItem;
    public GameObject currentThis;
    public GameObject ply;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name == "ÀÚÆÇ±â1" && collision.CompareTag("Player") && active == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            ply = collision.gameObject;
            ply.GetComponent<PlayerController>().playerMove = false;
        }
    }

    public void PressYesButton()
    {
        InventoryTest inven = ply.GetComponent<InventoryTest>();
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty)
            {
                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                inven.slots[i].isEmpty = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
                ply.GetComponent<PlayerController>().playerMove = true;
                break;
            }
        }
    }

    public void PreesNoButton()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        ply.GetComponent<PlayerController>().playerMove = true;
    }

    private void OnMouseEnter()
    {
        active = true;
    }

    private void OnMouseExit()
    {
        active = false;
    }
}
