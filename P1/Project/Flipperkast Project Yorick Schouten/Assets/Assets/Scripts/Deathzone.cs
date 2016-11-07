using UnityEngine;
using System.Collections;

public class Deathzone : MonoBehaviour {
    
    public void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Pinball" || col.gameObject.name == "Pinball(Clone)")
        {
            Destroy(col.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().lives -= 1;
            GameObject.Find("GameManager").GetComponent<GameManager>().saviorLeft = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().saviorRight = true;
            GameObject.Find("PlungerTrigger").GetComponent<BallCreate>().CreateBall();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
