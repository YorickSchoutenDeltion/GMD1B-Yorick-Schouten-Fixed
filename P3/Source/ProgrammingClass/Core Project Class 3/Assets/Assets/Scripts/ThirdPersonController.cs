using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    private float hor;
    private float ver;
    private float horCam;
    private float verCam;
    public float camRange;
    public float moveSpeed;
    public float turnSpeed;
    public float jumpStrength;
    public float gravity;
    public float mass;

    private Vector3 playerMove;
    private Vector3 playerRotate;
    private Vector3 axisRotate;
    private Vector3 towardsCam;
    private Vector3 camDefault;
    private Vector3 propCamPos;

    public Transform playerTrans;

    public GameObject playerCam;
    public GameObject playerObj;
    public GameObject camAxis;

    private RaycastHit camRay;
    private RaycastHit playerRay;

    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        MoveVars();
        PlayerMove();
        PlayerRotate();
        CamCol();
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
        towardsCam = (playerCam.transform.position - playerObj.transform.position).normalized;
        Debug.Log("First calculation of towardsCam is; " + towardsCam);
        propCamPos.z = towardsCam.z * camRange;
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

    // This checks if the camera is being blocked by a collider and moves it accordingly
    void CamCol()
    {
        print(towardsCam);
        playerCam.transform.position = playerTrans.position + (towardsCam * camRange);
        // playerCam.transform.position = camDefault;
        Debug.DrawRay(playerCam.transform.position, -towardsCam, Color.green);
        if (Physics.Raycast(playerCam.transform.position, -towardsCam, out playerRay, Mathf.Infinity))
        {
            if (!(playerRay.transform.tag == playerTrans.tag))
            {
                Debug.Log("Raycast hit " + playerRay.transform.name);
                Debug.DrawRay(transform.position, towardsCam, Color.red);
                if (Physics.Raycast(transform.position, towardsCam, out camRay, Mathf.Infinity))
                {
                    if (!(camRay.transform.tag == "MainCamera"))
                    {
                        playerCam.transform.position = camRay.point;
                    }
                }
            }
        }
    }
}
