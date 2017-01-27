using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_FirstPersonController : MonoBehaviour {

    public int jumps;

    private int jumpsLeft;

    public float speed;
    public float mouseSens;
    public float groundRay;

    private float hor;
    private float ver;
    private float mouseHor;
    private float mouseVer;

    public GameObject cam;

    private Vector3 movement;
    private Vector3 playerRotate;
    private Vector3 camMovement;

    public Vector3 jumpForce;

    private bool grounded;
    private bool mouseLocked;

    public Rigidbody playerRigid;

    public void Update()
    {
        PlayerMove();
        CameraMove();
        Jump();
    }

    void PlayerMove()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        mouseHor = Input.GetAxis("Mouse X");

        movement.x = hor;
        movement.z = ver;
        playerRotate.y = mouseHor;

        transform.Translate(movement * speed * Time.deltaTime);
        transform.Rotate(playerRotate * mouseSens * Time.deltaTime);
    }

    void CameraMove()
    {
        mouseVer = -Input.GetAxis("Mouse Y");

        camMovement.x = mouseVer;

        cam.transform.Rotate(camMovement * mouseSens * Time.deltaTime);
    }

    void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundRay))
        {
            grounded = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                playerRigid.velocity = (jumpForce);
                grounded = false;
            }

            else
            {
                if (jumpsLeft < 0)
                {
                    playerRigid.velocity = (jumpForce);
                    jumpsLeft -= 1;
                }
            }
        }
    }
}
