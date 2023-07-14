using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public FixedJoystick joystickObj;
    public Button interactButton;

    private GameObject player;
    private Animator playerAnim;
    

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerAnim = player.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            joystickObj.Horizontal * moveSpeed * Time.deltaTime, 0, 0);

        Vector3 changeScale = new Vector3(-1, 1, 1);

        if (joystickObj.Horizontal >= 1)
        {
            playerAnim.SetBool("isWalking", true);
            player.transform.localScale = new Vector3(
                1, player.transform.localScale.y, 1);
        }
        else if (joystickObj.Horizontal <= -1)
        {
            playerAnim.SetBool("isWalking", true);
            player.transform.localScale = new Vector3(
                -1, player.transform.localScale.y, 1);
        }
        else
            playerAnim.SetBool("isWalking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door")) 
        {
            interactButton.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            interactButton.interactable = false;
        }
    }
}
