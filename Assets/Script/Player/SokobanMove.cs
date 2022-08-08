using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SokobanMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 inputPos;
    Vector2 dir;
    private void Update()
    {
        //float inputX = Input.GetAxisRaw("Horizontal");
        //float inputY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = inputPos - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, inputPos, Time.deltaTime * moveSpeed);

        //transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * moveSpeed);
    }
}
