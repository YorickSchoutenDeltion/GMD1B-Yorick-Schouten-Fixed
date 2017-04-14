using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_EnemyMarker : MonoBehaviour {

    public int maxMarks;
    private int currentMarks;

    public RaycastHit ray;

    public GameObject marker;
    public GameObject gameManager;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CheckEnemy();
        }
    }

    void CheckEnemy()
    {
        if(Physics.Raycast(transform.position, transform.forward, out ray, Mathf.Infinity))
        {
            if(ray.transform.tag == "Enemy")
            {
                Vector3 instPos = ray.transform.position;
                instPos.y = 3;
                GameObject mark = (GameObject)Instantiate(marker, instPos, Quaternion.identity);
                mark.transform.parent = ray.transform;
            }
        }
    }
}
