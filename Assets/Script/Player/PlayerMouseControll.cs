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
    public bool playerMove = true;
    
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
            anim.SetBool("isWalking", true);
            dir = target - transform.position;
            if (dir.x > 0 && facingRight == false)
            {
                Flip();
            }
            if (dir.x < 0 && facingRight == true)
            {
                Flip();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        dir = target - transform.position;
        if(dir.x == 0)
        {
            anim.SetBool("isWalking", false);
        }
        
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Door"))
        {
            if (other.GetComponent<Teleporter>().mytest == true)
            {
                Debug.Log("Hi");
                
                transform.position = other.GetComponent<Teleporter>().GetDestination().position;
                other.GetComponent<Teleporter>().mytest = false;
                
            }
        }
    }
}
