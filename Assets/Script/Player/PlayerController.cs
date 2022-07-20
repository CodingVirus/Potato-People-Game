using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject drugCombiner;
    public float speed = 6.0f;
    Rigidbody2D rb;
    bool facingRight = true;

    Vector3 mousePosition;
    Vector2 dir;
    Vector3 storeYpos;

    public bool playerMove = true;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (playerMove == true)
            PlayerMouseMove();
        //PlayerKeyMove();
        DrugCombinerActive();
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

    private void DrugCombinerActive()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (drugCombiner != null)
            {
                drugCombiner.SetActive(true);
                playerMove = false;
                //speed = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (drugCombiner != null)
            {
                drugCombiner.SetActive(false);
                playerMove = true;
                //speed = 6.0f;
            }
        }
    }
    private void PlayerKeyMove()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        // ĳ���� �¿� �̵��� �ٶ󺸴� ���� ��ȯ
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
    }
    private void PlayerMouseMove()
    {
        if (Input.GetMouseButton(0))
        {
            storeYpos.y = transform.position.y;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = storeYpos.y;

            dir = mousePosition - transform.position;

            if (dir.x > 0 && facingRight == false)
            {
                Flip();
            }
            else if (dir.x < 0 && facingRight == true)
            {
                Flip();
            }
            if (dir != Vector2.zero)
                anim.SetBool("isWalking", true);
            

            transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * speed);
            //Debug.Log(transform.position+" " +mousePosition);
        }
        else
            anim.SetBool("isWalking", false);
    }
}
