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
        if (this.name == "자판기1" && collision.CompareTag("Player") && active == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            ply = collision.gameObject;
            ply.GetComponent<PlayerMouseControll>().StopMove();
        }

        else if (this.name == "조합도구1" && collision.CompareTag("Player") && active == true)
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
                //slotItem.GetComponent<Button>().onClick.AddListener(UseItem);
                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
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
        Debug.Log(slotItem.name);
        if (slotItem.name == "Coke(Clone)")
        {
            Debug.Log("Coke!!!");
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
