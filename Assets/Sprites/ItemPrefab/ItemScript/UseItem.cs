using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public int num;
    public GameObject useItemPlayer;
    
    public void Useitem()
    {
        num = int.Parse(this.name.Substring(this.name.IndexOf("_") + 1));
        
        if (this.transform.GetChild(0).name == "Coke(Clone)")
        {
            Debug.Log("Coke!!!");
            Destroy(this.transform.GetChild(0).gameObject);
            useItemPlayer.GetComponent<InventoryTest>().slots[num].isEmpty = true;
        }
    }
}
