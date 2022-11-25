using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform montarget;

    public int nextMove;
    public float thinkTime;
    public float monSpeed;
    public float traceSpeed;

    private bool facingRight;
    private Vector3 dir;
    private float dis;
    public bool traceState = false;
    private int count = 0;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Think");
    }

    private void FixedUpdate() 
    {
        if(montarget.GetComponent<PlayerTeleport>().transferState == false)
        {
            dis = Vector3.Distance(transform.position, montarget.position);

            //낭떠러지 감지
            Sensor();
            //if(montarget.GetComponent<PlayerTeleport>().door3 == true)
            //{
                if(dis > 10 ||(dis > 10 && traceState == true)||(dis <= 10 && montarget.GetComponent<PlayerHide>().hideStart == true))
                {
                    Move();
                    Flip();
                    traceState = false;
                    if(count == 1)
                    {
                        StartCoroutine("Think");
                        count = 0;
                    }
                } 
                // else if(dis > 10 && traceState == true)
                // {
                //     StartCoroutine("Think");
                //     traceState = false;
                // }
                // else if(dis <= 10 && montarget.GetComponent<PlayerHide>().hideStart == true){
                //     traceState = false;
                //     StartCoroutine("Think");
                // }
                else if(dis <= 10)
                {
                    Trace();
                    traceState = true;
                    if(count == 0)
                    {
                        count++;
                    }      
                }
            //}
        }
    }
    
    private void Move()
    {
        rigid.velocity = new Vector2(nextMove * monSpeed, rigid.velocity.y);
    }

    IEnumerator Think()
    {   
        while (true)
        {
            nextMove = Random.Range(-1, 2);
            thinkTime = Random.Range(1, 10);
            Debug.Log(nextMove);
            Debug.Log(thinkTime);
            yield return new WaitForSeconds(thinkTime);
        }
    }

    private void Trace()
    {
        transform.position = Vector2.MoveTowards(transform.position , montarget.position, Time.smoothDeltaTime * traceSpeed);
        dir = montarget.position - transform.position;
        Flip();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(traceState == true)
            {
                Debug.Log("gameover");
                SceneManager.LoadScene(1);
            }
        }
    }

    void Sensor()
    {
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
        if(raycast.collider == null)
        {
            //Debug.Log("낭떠러지");
            nextMove = nextMove * (-1);
        }
    }

    void Flip()
    {
        if ((nextMove > 0 && facingRight == false && traceState == false) || (dir.x > 0 && facingRight == false && traceState == true))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
        if ((nextMove < 0 && facingRight == true && traceState == false) || (dir.x < 0 && facingRight == true && traceState == true))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
    }
}
