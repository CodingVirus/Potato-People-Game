using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public int num;
    public void Useitem()
    {
        Debug.Log(this.name);
        if (this.name == "Coke(Clone)")
        {
            GameObject go = this.transform.parent.gameObject;
            //Debug.Log(this.transform.parent.name);
            num = int.Parse(go.name.Substring(go.name.IndexOf("_") + 1));
            Debug.Log("Use Coke!!!");
            
            Destroy(this.gameObject);
        }
    }

    public void UseTest()
    {
        Debug.Log(this.transform.GetChild(0).name);
        if (this.transform.GetChild(0).name == "Coke")
        {
            Debug.Log("Coke!!!");
        }
    }

}
