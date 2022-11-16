using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIckUp : MonoBehaviour
{
    public bool active = false;
    public GameObject slotItem;
    public GameObject ply;
    public GameObject gameData;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (this.name == "Vending Machine" && collision.CompareTag("Player") && active == true)
        //{
        //    ply = collision.gameObject;
        //    //ply.GetComponent<PlayerMouseControll>().StopMove();
        //    Inventory inven = ply.GetComponent<Inventory>();
        //    for (int i = 0; i < inven.slots.Count; i++)
        //    {
        //        if (inven.slots[i].isEmpty)
        //        {
        //            Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
        //            inven.slots[i].isEmpty = false;
        //            //this.GetComponent<BoxCollider2D>().enabled = false;
        //            break;
        //        }
        //    }
        //    active = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name == "Drug Combiner" && collision.CompareTag("Player") && active == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            ply = collision.gameObject;
            this.transform.GetChild(0).GetChild(0).gameObject.GetComponent<DrugCombination>().drugCombinerPlayerObj = ply.gameObject;
            this.GetComponent<UItriggerOff>().TriggerOff();
            ply.GetComponent<PlayerMouseControll>().StopMove();
        }
    }

    public void GetItem()
    {
        //ply = collision.gameObject;
        //ply.GetComponent<PlayerMouseControll>().StopMove();
        Inventory inven = ply.GetComponent<Inventory>();
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty)
            {
                Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                inven.slots[i].isEmpty = false;
                //this.GetComponent<BoxCollider2D>().enabled = false;
                break;
            }
        }
    }
    private void OnMouseDown()
    {
        active = true;
    }
    
}
