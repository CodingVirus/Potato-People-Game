using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ply;

    private void OnMouseDown()
    {
        ply.GetComponent<PlayerHide>().HideEnter();
        this.gameObject.SetActive(false);
    }

    public void HideTest()
    {
        ply.GetComponent<PlayerHide>().HideEnter();
    }
}
