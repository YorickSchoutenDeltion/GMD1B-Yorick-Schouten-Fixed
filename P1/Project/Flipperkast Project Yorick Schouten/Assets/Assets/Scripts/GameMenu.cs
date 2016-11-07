using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    public float flipperStrength;
    public float pushForce;
    private HingeJoint hinge;

	void Start () {
        hinge = GetComponent<HingeJoint>();
	}
	
	void FixedUpdate () {
	    if (Input.GetButtonDown("Jump"))
        {
            Vector3 f = transform.up * flipperStrength;
            Vector3 p = (transform.right) + transform.position * pushForce;
            GetComponent<Rigidbody>().AddForceAtPosition(f, p);
        }
	}
}
