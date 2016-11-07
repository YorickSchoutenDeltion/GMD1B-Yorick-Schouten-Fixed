using UnityEngine;
using System.Collections;

public class FlipperMovementLeft : MonoBehaviour {

    private bool pressed = false;
    private object motor;
    

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	
	}

    void FixedUpdate ()
    {
        if (Input.GetButton("Left Flipper"))
        {
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointMotor motor = hinge.motor;
            motor.force = 500;
            motor.targetVelocity = -900;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
        }
        else
        {
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointMotor motor = hinge.motor;
            motor.force = 500;
            motor.targetVelocity = 900;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
        }


        }
    }

