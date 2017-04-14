using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_CharacterController : MonoBehaviour {

    private float hor;
    private float ver;
    private float horCam;
    private float verCam;
    public float moveSpeed;
    public float turnSpeed;

    private Vector3 playerMove;
    private Vector3 playerRotate;
    private Vector3 axisRotate;
    private Vector3 towardsPlane;

    public GameObject playerCam;
    public GameObject playerObj;
    public GameObject camAxis;
    public GameObject rayPlane;
    public GameObject currentConvoTarget;

    private RaycastHit camRay;
    private RaycastHit talkRay;

    public enum PlayerState {playing, talking};
    public PlayerState myState;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Interact();
        }
    }

    void FixedUpdate()
    {
        if (myState == PlayerState.playing)
        {
            MoveVars();
            PlayerMove();
            PlayerRotate();
            CamClip();
        }
        if (myState == PlayerState.talking)
        {
            MoveVars();
            PlayerRotate();
            CamClip();
            TalkButtons();
        }
    }

    // This provides input buttons for talking
    void TalkButtons()
    {
        if (Input.GetButtonDown("Yes"))
        {
            GetComponent<DEV_DialogueManager>().ProgressDialogue(1);
        }
        if (Input.GetButtonDown("No"))
        {
            GetComponent<DEV_DialogueManager>().ProgressDialogue(2);
        }
    }

    // This provides the player an input button to interact with objects in the game world.
    void Interact()
    {
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * 1000, Color.red);
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out talkRay, Mathf.Infinity))
        {
            if (talkRay.transform.tag == "NPC")
            {
                myState = PlayerState.talking;
                currentConvoTarget = talkRay.transform.gameObject;
                GetComponent<DEV_DialogueManager>().StartDialogue(talkRay.transform.gameObject);
            }
        }
    }

    // This sets the various movement variables to their appropriate values
    void MoveVars()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        horCam = Input.GetAxis("Mouse X");
        verCam = Input.GetAxis("Mouse Y");
        playerMove.x = hor;
        playerMove.z = ver;
        playerRotate.y = horCam;
        axisRotate.x = -verCam;
    }

    // This causes the player object to move when input is given
    void PlayerMove()
    {
        transform.Translate(playerMove * moveSpeed * Time.deltaTime);
    }

    // This controls the rotation of the player and camera
    void PlayerRotate()
    {
        playerObj.transform.Rotate(playerRotate * turnSpeed * Time.deltaTime);
        camAxis.transform.Rotate(axisRotate * turnSpeed * Time.deltaTime);
    }

    // This ensures the camera doesn't clip into any colliders
    void CamClip()
    {
        towardsPlane = (rayPlane.transform.position - camAxis.transform.position);
        Debug.DrawRay(camAxis.transform.position, towardsPlane * 10000, Color.green);
        if(Physics.Raycast(camAxis.transform.position, towardsPlane, out camRay, Mathf.Infinity))
        {
            playerCam.transform.position = camRay.point;
        }
    }
}
