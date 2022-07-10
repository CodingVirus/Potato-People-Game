using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject drugCombiner;
    public float speed = 6.0f;
    Rigidbody2D rb;
    bool facingRight = true;

    Vector3 mousePos, transPos, targetPos;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime + speed);
    }
    private void Update()
    {


        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        // 캐릭터 좌우 이동시 바라보는 방향 전환
        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }

        if (input != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (speed == 0)
        {
            anim.SetBool("isWalking", false);
            if (input != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            if (speed == 0)
            {
                anim.SetBool("isWalking", false);
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (drugCombiner != null)
            {
                drugCombiner.SetActive(true);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (drugCombiner != null)
            {
                drugCombiner.SetActive(false);
            }
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DrugCombiner"))
        {
            drugCombiner = collision.gameObject.transform.GetChild(0).gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DrugCombiner"))
        {
            drugCombiner = null;
        }
    }
}
