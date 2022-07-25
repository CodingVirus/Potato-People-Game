using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIckUp : MonoBehaviour
{
    private bool active = false;
    public GameObject slotItem;
    public GameObject ply;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name == "Vending Machine" && collision.CompareTag("Player") && active == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            ply = collision.gameObject;
            ply.GetComponent<PlayerMouseControll>().StopMove();
        }

        else if (this.name == "Drug Combiner" && collision.CompareTag("Player") && active == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            ply = collision.gameObject;
            ply.GetComponent<PlayerMouseControll>().StopMove();
        }
    }

    public void PressYesButton()
    {
        InventoryTest inven = ply.GetComponent<InventoryTest>();
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty)
            {
                GameObject test = Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                //test.GetComponent<Button>().onClick.AddListener(UseItem);
                inven.slots[i].isEmpty = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
                break;
            }
        }
        ply.GetComponent<PlayerMouseControll>().target = ply.transform.position;
        ply.GetComponent<PlayerMouseControll>().StartMove();
        active = false;
    }

    public void UseItem()
    {
        if (slotItem.name == "Coke")
        {
            Debug.Log("Coke!!!");
            
        }

        else if (slotItem.name == "Drug")
        {
            Debug.Log("Drug!!!");
        }
    }

    public void PreesNoButton()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        active = false;
        ply.GetComponent<PlayerMouseControll>().target = ply.transform.position;
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }

    private void OnMouseDown()
    {
        active = true;
    }
    //private void OnMouseEnter()
    //{
    //    active = true;
    //}

    //private void OnMouseExit()
    //{
    //    active = false;
    //}
    
}
