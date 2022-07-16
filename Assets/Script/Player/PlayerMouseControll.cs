using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControll : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Vector3 storeYpos;
    private Vector3 dir;

    Animator anim;
    bool facingRight = true;
    
    void Start()
    {
        target = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        target.y = transform.position.y;

        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            dir = target - transform.position;
            if (dir.x > 0 && facingRight == false)
            {
                transform.localScale = new Vector3(1, 1, 0);
                facingRight = !facingRight;
            }
            else if (dir.x < 0 && facingRight == true)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                facingRight = !facingRight;
            }
            if (dir != Vector3.zero)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
    
}
