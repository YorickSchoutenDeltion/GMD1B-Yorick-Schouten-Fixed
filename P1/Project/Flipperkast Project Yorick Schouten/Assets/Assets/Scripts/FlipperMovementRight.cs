using UnityEngine;
using System.Collections;

public class FlipperMovementRight : MonoBehaviour
{

    private bool pressed = false;
    private object motor;

    void FixedUpdate()
    {
        if (Input.GetButton("Right Flipper"))
        {
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointMotor motor = hinge.motor;
            motor.force = 1000;
            motor.targetVelocity = 900;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
        }
        else
        {
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointMotor motor = hinge.motor;
            motor.force = 1000;
            motor.targetVelocity = -900;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
        }


    }
}

