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

    void Update()
    {
        Detector();
    }

    public void Detector()
    {
        rayDir = player.transform.position - transform.position;

        float angle = Vector3.Angle(rayDir, transform.forward);
        if(angle < fov)
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
}
