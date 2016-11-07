using UnityEngine;
using System.Collections;

public class BallCreate : MonoBehaviour {

    public Vector3 plungerPos;

    void Start()
    {
        plungerPos = transform.position;
    }

    public void CreateBall()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().lives > 0)
        {
            Instantiate(Resources.Load("Pinball"), plungerPos, Quaternion.identity);
        }
    }
}
