using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    private GameObject currentTeleporter;
    public GameObject fadeEffect;

    // Update is called once per frame
    void Update()
    {
        // 위 화살표 누르고 현재 currentTeleporter가 null이 아니라면 목적지 위치로 이동
        // Invoke 기능을 사용하여 0.5초뒤에 이동
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.GetComponent<PlayerController>().playerMove = false;
            if (currentTeleporter != null)
            {
                fadeEffect.GetComponent<FadeScript>().Fade();

                Invoke("MovePosition", 1.5f);

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
