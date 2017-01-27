using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_FirstPersonController : MonoBehaviour {

    public int jumps;

    private int jumpsLeft;

    public float speed;
    public float mouseSens;
    public float groundRay;
    public float throwerEmissionRate;

    private float hor;
    private float ver;
    private float mouseHor;
    private float mouseVer;

    public GameObject cam;
    public Light flameLight;

    private Vector3 movement;
    private Vector3 playerRotate;
    private Vector3 camMovement;

    public Vector3 jumpForce;

    private bool grounded;
    private bool mouseLocked;

    public Rigidbody playerRigid;

    public ParticleSystem flamethrower;

    private CursorLockMode wantedMode;

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide the cursor when looking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = wantedMode = CursorLockMode.None;
        }

        switch (Cursor.lockState)
        {
            case CursorLockMode.None:
                GUILayout.Label("Cursor is normal");
                if (GUILayout.Button("Lock cursor"))
                    wantedMode = CursorLockMode.Locked;
                if (GUILayout.Button("Confine cursor"))
                    wantedMode = CursorLockMode.Confined;
                break;
            case CursorLockMode.Confined:
                GUILayout.Label("Cursor is confined");
                if (GUILayout.Button("Lock cursor"))
                    wantedMode = CursorLockMode.Locked;
                if (GUILayout.Button("Release cursor"))
                    wantedMode = CursorLockMode.None;
                break;
            case CursorLockMode.Locked:
                GUILayout.Label("Cursor is locked");
                if (GUILayout.Button("Unlock cursor"))
                    wantedMode = CursorLockMode.None;
                if (GUILayout.Button("Confine cursor"))
                    wantedMode = CursorLockMode.Confined;
                break;
        }

        GUILayout.EndVertical();

        SetCursorState();
    }

    public void Update()
    {
        PlayerMove();
        CameraMove();
        Jump();
        EnableFlamethrower();
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

    void EnableFlamethrower()
    {
        if (Input.GetButtonDown("Fire 1"))
        {
            flamethrower.Play();
            flameLight.enabled = true;
        }

        if (Input.GetButtonUp("Fire 1"))
        {
            flamethrower.Stop();
            flameLight.enabled = false;
        }
    }
}
