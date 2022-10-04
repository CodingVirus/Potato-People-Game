using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    float MaxDistance = 15f;
    Vector3 MousePostion;
    Camera Camera;
    public GameObject ply;

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePostion = Input.mousePosition;
            MousePostion = Camera.ScreenToWorldPoint(MousePostion);

            RaycastHit2D hit = Physics2D.Raycast(MousePostion, transform.forward, MaxDistance);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Sheet")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    hit.transform.GetChild(0).gameObject.SetActive(true);

                    //Invoke("PlyMoveStart", 0.5f);
                }

                else if (hit.transform.gameObject.tag == "Diary")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    hit.transform.GetChild(0).gameObject.SetActive(true);

                    //Invoke("PlyMoveStart", 0.5f);
                }
            }
        }
    }

    public void PlyMoveStart()
    {
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }
}