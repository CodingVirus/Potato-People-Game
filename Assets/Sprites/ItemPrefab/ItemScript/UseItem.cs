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
            playerObj.GetComponent<InventoryTest>().slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Drug(Clone)")
        {
            Destroy(this.transform.GetChild(0).gameObject);
            Debug.Log(this.transform.GetChild(0).name);
            playerObj.GetComponent<InventoryTest>().slots[num].isEmpty = true;
        }

        else if (this.transform.GetChild(0).name == "Apple(Clone)")
        { 
            if (playerObj.GetComponent<InventoryTest>().slots[num].usingItem == false)
            {
                playerObj.GetComponent<InventoryTest>().slots[num].usingItem = true;
                playerObj.transform.Find("Lighter").gameObject.SetActive(true);
            }

            else if (playerObj.GetComponent<InventoryTest>().slots[num].usingItem == true)
            {
                playerObj.GetComponent<InventoryTest>().slots[num].usingItem = false;
                playerObj.transform.Find("Lighter").gameObject.SetActive(false);
            }
        }
    }
}
