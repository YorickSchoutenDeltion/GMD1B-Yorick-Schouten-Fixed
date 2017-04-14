using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_GuardController : MonoBehaviour {

    public float speed;
    public float detectionRange;
    public float detectionRate;
    public float currDetection;
    public float detectMercy;
    public float fov;

    private RaycastHit checkRay;

    private Vector3 rayDir;

    public GameObject player;

    public enum AIState {Neutral, Hostile};
    public AIState myState;

    void Update()
    {
        if (myState == AIState.Hostile)
        {
            Detector();
        }
    }

    // This allows the guard object to find the player in their field of view and raises a detection meter
    public void Detector()
    {
        rayDir = player.transform.position - transform.position;

        float angle = Vector3.Angle(rayDir, transform.forward);
        if (angle < fov)
        {
            Debug.DrawRay(transform.position, rayDir, Color.yellow, 0.1f);
            if (Physics.Raycast(transform.position, rayDir.normalized, out checkRay, detectionRange))
            {
                if (checkRay.transform.tag == "Player")
                {
                    currDetection += Time.deltaTime * detectionRate;
                }
            }
        }
    }

    // This toggles the behavior of the guard
    public void ChangeBehavior()
    {
        if (myState == AIState.Neutral)
        {
            myState = AIState.Hostile;
        }
        if (myState == AIState.Hostile)
        {
            myState = AIState.Neutral;
        }
    }
}
