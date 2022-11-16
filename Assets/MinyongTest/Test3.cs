using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    public GameObject ply;
    public GameObject des;
    public GameObject test;

    public Vector3 p_Teleport;
    public CameraFollow theCamera;

    private void OnMouseDown()
    {
        //ply.GetComponent<PlayerTeleport>().Fade();

        //CameraMove();
        //ply.transform.position = this.GetComponent<Teleporter>().GetDestination().position;

        //ply.GetComponent<PlayerMouseControll>().target = transform.position;
        //p_Teleport = transform.position;
        
        //PlayerMouseControll.instance.StartMove();
        // ply.transform.position = des.transform.position;
    }

    private void CameraMove()
    {
        //T_camera = true;
        theCamera.limitMinX = test.GetComponent<Teleporter>().T_limitMinX;
        theCamera.limitMaxX = test.GetComponent<Teleporter>().T_limitMaxX;
        theCamera.limitMinY = test.GetComponent<Teleporter>().T_limitMinY;
        theCamera.limitMaxY = test.GetComponent<Teleporter>().T_limitMaxY;
        Debug.Log("º¯°æ");
    }

    public void MoveTest()
    {
        
        ply.transform.position = test.GetComponent<Teleporter>().GetDestination().position;
        CameraMove();
    }
}
