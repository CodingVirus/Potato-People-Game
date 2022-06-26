using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    private GameObject currentTeleporter;
    public GameObject fadeEffect;

    private void Start()
    {
        //test.GetComponent<FadeScript>();
    }
    // Update is called once per frame
    void Update()
    {
        // �� ȭ��ǥ ������ ���� currentTeleporter�� null�� �ƴ϶�� ������ ��ġ�� �̵�
        // Invoke ����� ����Ͽ� 0.5�ʵڿ� �̵�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if (currentTeleporter != null)
            {
                fadeEffect.GetComponent<FadeScript>().Fade();
                this.GetComponent<PlayerController>().playerMove = false;
                Invoke("MovePosition", 0.5f);
                
            }
        }
    }

    private void MovePosition()
    {
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerController>().playerMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
