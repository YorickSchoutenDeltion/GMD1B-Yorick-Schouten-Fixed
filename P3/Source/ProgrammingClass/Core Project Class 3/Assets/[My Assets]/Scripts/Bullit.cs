using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullit : MonoBehaviour {

    public float deathTime;

	void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            Destroy(col.gameObject);
        }

        else
        {
            deathTime -= Time.deltaTime;
            if(deathTime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
