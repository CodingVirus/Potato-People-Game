using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobilePlayerMovement : MonoBehaviour
{
    public FixedJoystick joystickObj;
    public Button doorButton;

    public float moveSpeed = 5f;

    private Teleporter destinationDoor;
    public Animator playerAnim;
    private CameraFollow theCamera;

    public bool isPlayerMove = true;

    private void Awake()
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }
    void Update()
    {
        PlayerMovement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door")) 
        {
            doorButton.interactable = true;
            destinationDoor = collision.GetComponent<Teleporter>();            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            doorButton.interactable = false;
        }
    }
    
    private void PlayerMovement()
    {
        transform.position += new Vector3(
            joystickObj.Horizontal * moveSpeed * Time.deltaTime, 0, 0);

        if (joystickObj.Horizontal >= 1 && isPlayerMove == true)
        {
            playerAnim.SetBool("isWalking", true);
            this.transform.localScale = new Vector3(
                1, this.transform.localScale.y, 1);

            this.transform.GetChild(0).localScale = new Vector3(
                0.02f, 0.02f, 0);
        }
        else if (joystickObj.Horizontal <= -1 && isPlayerMove == true)
        {
            playerAnim.SetBool("isWalking", true);
            this.transform.localScale = new Vector3(
                -1, this.transform.localScale.y, 1);

            this.transform.GetChild(0).localScale = new Vector3(
                -0.02f, 0.02f, 0);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }
    }
    public void PlayerMoveStop()
    {
        joystickObj.SetInputZero();
        isPlayerMove = false;
        moveSpeed = 0f;
    }

    public void PlayerMoveStart()
    {
        isPlayerMove = true;
        moveSpeed = 5f;
    }

    public void TeleportDoor()
    {
        transform.position = destinationDoor.GetDestination().transform.position;

        theCamera.limitMaxX = destinationDoor.T_limitMaxX;
        theCamera.limitMinX = destinationDoor.T_limitMinX;
        theCamera.limitMaxY = destinationDoor.T_limitMaxY;
        theCamera.limitMinY = destinationDoor.T_limitMinY;
    }
}
