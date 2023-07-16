using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePlayerMovement : MBCharactorStat
{
    public FixedJoystick joystickObj;
    public Button doorButton;
    public Button interactionButton;

    private Teleporter destinationDoor;
    private Animator playerAnim;
    private CameraFollow theCamera;

    private void Awake()
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
        playerAnim = this.GetComponent<Animator>();
    }
    void Update()
    {
        transform.position += new Vector3(
            joystickObj.Horizontal * moveSpeed * Time.deltaTime, 0, 0);

        Vector3 changeScale = new Vector3(-1, 1, 1);

        if (joystickObj.Horizontal >= 1)
        {
            playerAnim.SetBool("isWalking", true);
            this.transform.localScale = new Vector3(
                1, this.transform.localScale.y, 1);
        }
        else if (joystickObj.Horizontal <= -1)
        {
            playerAnim.SetBool("isWalking", true);
            this.transform.localScale = new Vector3(
                -1, this.transform.localScale.y, 1);
        }
        else
            playerAnim.SetBool("isWalking", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door")) 
        {
            doorButton.interactable = true;
            destinationDoor = collision.GetComponent<Teleporter>();            
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            interactionButton.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            doorButton.interactable = false;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            interactionButton.interactable = false;
        }
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
