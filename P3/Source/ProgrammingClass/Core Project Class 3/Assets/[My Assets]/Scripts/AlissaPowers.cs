using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlissaPowers : MonoBehaviour {

    public GameObject plrCam;
    private GameObject grabbedItem;

    public float grabRange;

    private RaycastHit grabRay;

    private bool itemGrabbed;

    private Vector3 grabPos;

    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            GrabObject();
        }
        if (itemGrabbed == true)
        {
            ControlItem();
        }
    }

    // This attempts to find an object to grab using a raycast
    public void GrabObject()
    {
        if(Physics.Raycast(plrCam.transform.position, plrCam.transform.forward, out grabRay, grabRange))
        {
            if(grabRay.transform.tag == "Physics")
            {
                grabbedItem = grabRay.transform.gameObject;
                itemGrabbed = true;
            }
        }
    }

    // This runs when an object is found with GrabObject and controls the held object
    void ControlItem()
    {
        grabPos = plrCam.transform.position;
        grabPos.z = grabRange;
        grabbedItem.transform.position = grabPos;
    }
}
