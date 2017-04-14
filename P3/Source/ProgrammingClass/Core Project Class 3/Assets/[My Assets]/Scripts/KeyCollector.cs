using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour {

    public GameObject manager;

	void OnCollisionEnter ()
    {
        manager.GetComponent<GameManager>().actual.Add(gameObject);
        transform.position = new Vector3(100, 100, 100);
	}
}
