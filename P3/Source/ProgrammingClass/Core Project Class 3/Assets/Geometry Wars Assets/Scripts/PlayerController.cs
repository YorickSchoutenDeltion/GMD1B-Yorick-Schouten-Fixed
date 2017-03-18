using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;
    public float turnSpeed;

    private Vector3 clickPos;
    private Vector3 turnPos;
    private Vector3 movement;
    private Quaternion targetPos;

    public Transform cube;

    public LayerMask rayMask;

    void FixedUpdate()
    {
        TurnPlayer();
        MovePlayer();
    }

    public void MovePlayer()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void TurnPlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100))
        {
            cube.position = hit.point;
            targetPos = Quaternion.LookRotation(hit.point - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPos, turnSpeed * Time.deltaTime);
        }

        //float ver = Input.GetAxis("JoyVertical");
        //float hor = Input.GetAxis("JoyHorizontal");

        //if (Input.GetAxis("JoyVertical") != 0 || Input.GetAxis("JoyHorizontal") != 0)
        //{
        //    turnPos.x = hor;
        //    turnPos.z = ver;
        //    targetPos = Quaternion.LookRotation(turnPos, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetPos, turnSpeed * Time.deltaTime);
        //}
    }

}
