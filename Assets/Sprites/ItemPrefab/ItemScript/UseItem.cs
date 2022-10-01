using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public int num;
    public GameObject playerObj;

    public void Useitem()
    {
        //playerObj.GetComponent<PlayerMouseControll>().StopMove();
        num = int.Parse(this.name.Substring(this.name.IndexOf("_") + 1));
        
        if (this.transform.GetChild(0).name == "Coke(Clone)")
        {
            Debug.Log("Coke!!!");
            Destroy(this.transform.GetChild(0).gameObject);
            playerObj.GetComponent<Inventory>().slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Drug(Clone)")
        {
            Destroy(this.transform.GetChild(0).gameObject);
            Debug.Log(this.transform.GetChild(0).name);
            playerObj.GetComponent<Inventory>().slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Lighter(Clone)")
        { 
            if (playerObj.GetComponent<Inventory>().slots[num].usingItem == false)
            {
                playerObj.GetComponent<Inventory>().slots[num].usingItem = true;
                playerObj.transform.Find("Lighter").gameObject.SetActive(true);
            }

            else if (playerObj.GetComponent<Inventory>().slots[num].usingItem == true)
            {
                playerObj.GetComponent<Inventory>().slots[num].usingItem = false;
                playerObj.transform.Find("Lighter").gameObject.SetActive(false);
            }
        }
    }

    public void UseItemDialogue(string input)
    {
        for (int i = 0; i < playerObj.GetComponent<Inventory>().slots.Count; i++)
        {
            if (playerObj.GetComponent<Inventory>().slots[i].isEmpty == false && playerObj.GetComponent<Inventory>().slots[i].slotObj.transform.GetChild(0).name == input)
            {
                //Debug.Log("HI");
                Destroy(playerObj.GetComponent<Inventory>().slots[i].slotObj.transform.GetChild(0).gameObject);
                playerObj.GetComponent<Inventory>().slots[i].isEmpty = true;
            }

            else
            {
                continue;
            }
        }
    }
}
