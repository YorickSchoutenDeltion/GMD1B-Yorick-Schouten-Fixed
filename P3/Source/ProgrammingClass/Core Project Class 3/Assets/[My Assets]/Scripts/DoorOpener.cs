using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    public GameObject manager;

    void OnCollisionEnter()
    {
        print("ello");
        if (manager.GetComponent<GameManager>().CheckList())
        {
            Destroy(gameObject);
        }
    }
}
