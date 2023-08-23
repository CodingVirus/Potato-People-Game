using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    public int num;
    public GameObject playerObj;

    private Inventory inven;

    private void Start()
    {
        inven = playerObj.GetComponent<Inventory>();
    }

    public void AddItem(GameObject item)
    {
        inven.AddItem(item);
    }
    public void Useitem()
    {
        num = int.Parse(this.name.Substring(this.name.IndexOf("_") + 1));

        if (this.transform.GetChild(0).name == "Coke(Clone)")
        {
            Debug.Log("Coke!!!");
            Destroy(this.transform.GetChild(0).gameObject);
            inven.slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Drug(Clone)")
        {
            Destroy(this.transform.GetChild(0).gameObject);
            Debug.Log(this.transform.GetChild(0).name);
            inven.slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Lighter(Clone)")
        { 
            if (inven.slots[num].usingItem == false)
            {
                inven.slots[num].usingItem = true;
                playerObj.transform.Find("Lighter").gameObject.SetActive(true);
            }

            else if (inven.slots[num].usingItem == true)
            {
                inven.slots[num].usingItem = false;
                playerObj.transform.Find("Lighter").gameObject.SetActive(false);
            }
        }
    }

    public void ThrowItem(string name)
    {
        num = int.Parse(this.name.Substring(this.name.IndexOf("_") + 1));

        if (name == "Coke(Clone)")
        {
            Debug.Log("Thorw Coke!!!");
            Destroy(this.transform.GetChild(0).gameObject);
            inven.slots[num].isEmpty = true;
        }

        else
        {
            Destroy(this.transform.GetChild(0).gameObject);
            inven.slots[num].isEmpty = true;
        }
    }

    public void UseItemDialogue(string input)
    {
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty == false && inven.slots[i].slotObj.transform.GetChild(0).name == input)
            {
                Destroy(inven.slots[i].slotObj.transform.GetChild(0).gameObject);
                inven.slots[i].isEmpty = true;
                break;
            }

            else
            {
                continue;
            }
        }
    }
}
