using UnityEngine;
using System.Collections;

public class TestingBallBehaviour : MonoBehaviour {

    public float currentForce;
    private float counter = 5;
    public float maximumForce = 5;
    public float timer;

	void Update () {
        if (Input.GetButton("Jump"))
        {
            if (currentForce < maximumForce)
            {
                timer += Time.deltaTime;
                if (timer > 0.25f)
                {
                    currentForce += 0.4f;
                    timer -= 0.25f;
                }
            }
        }

	
	}

    void OnTriggerStay (Collider col)
    {
        if (col.name == "PlungerTrigger")
        {

            if (Input.GetButtonUp("Jump"))
            {
                transform.rotation = Quaternion.identity;
                GetComponent<Rigidbody>().AddForce(transform.forward * currentForce * 800);
                currentForce = 0;
            }
        }
    
    }
    
    void OnTriggerEnter (Collider col)
    {
        if (col.name == "SaviorLeft")
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().saviorLeft == true)
            {
                transform.rotation = Quaternion.identity;
                GetComponent<Rigidbody>().AddForce(transform.forward * 2500);
                GameObject.Find("GameManager").GetComponent<GameManager>().saviorLeft = false;
            }
        }
        if (col.name == "SaviorRight")
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().saviorRight == true)
            {
                transform.rotation = Quaternion.identity;
                GetComponent<Rigidbody>().AddForce(transform.forward * 2500);
                GameObject.Find("GameManager").GetComponent<GameManager>().saviorRight = false;
            }
        }
    }
}
