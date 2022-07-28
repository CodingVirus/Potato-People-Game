using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerInven : MonoBehaviour
{
    public GameObject stopPlyObj;
    private void OnMouseEnter()
    {
        stopPlyObj.GetComponent<PlayerMouseControll>().target = stopPlyObj.transform.position;
        stopPlyObj.GetComponent<PlayerMouseControll>().StopMove();
    }

    private void OnMouseExit()
    {
        stopPlyObj.GetComponent<PlayerMouseControll>().target = stopPlyObj.transform.position;
        stopPlyObj.GetComponent<PlayerMouseControll>().StartMove();
    }
}
