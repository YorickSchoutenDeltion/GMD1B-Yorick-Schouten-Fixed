using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CController : MonoBehaviour {

    public float hor;
    public float ver;
    public float speed;
    public Vector3 movement;
    public Rigidbody rb;

    void FixedUpdate()
    { 
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);		
	}
}
