using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public List<Transform> waypoints = new List<Transform>();

    public Transform playerTransform;
    public GameObject bullet;
    public GameObject instbullet;

    public float movespeed;
    public float aggroModifier;
    private float distance;
    public float maxDistance;
    public float shotTimerCap;
    private float shotTimer;

    public int index;

    public Vector3 target;
    public Vector3 moveDirection;

    public CharacterController character;

    public enum AIState {Patrol, Follow};
    public AIState myState;

    private RaycastHit hit;

	void Update()
    {
        if (playerTransform != null)
        {

            RangeCheck();
            if (myState == AIState.Patrol)
            {
                Patrol();
            }
            else
            {
                Aggro();
            }
        }
	}

    void Patrol()
    {
        target = waypoints[index].position;
        target.y = transform.position.y;
        moveDirection = target - transform.position;

        if(moveDirection.magnitude < 0.5)
        {
            if(index < (waypoints.Count-1))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        else
        {
            character.Move(moveDirection.normalized * movespeed * Time.deltaTime);
        }
    }
    void Aggro()
    {
        shotTimer -= Time.deltaTime;
        if(shotTimer < 0)
        {
            instbullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            instbullet.GetComponent<Rigidbody>().velocity = ((playerTransform.position - transform.position) * aggroModifier);
            shotTimer = shotTimerCap;
        }

        target = playerTransform.position;
        target.y = transform.position.y;
        moveDirection = target - transform.position;
        character.Move(moveDirection.normalized * movespeed * Time.deltaTime);
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance < maxDistance)
        {
            Debug.DrawRay(transform.position, (playerTransform.position - transform.position), Color.yellow, 0.3f);
            if(Physics.Raycast(transform.position, (playerTransform.position - transform.position), out hit, maxDistance))
            {
                if(hit.transform.tag == "Player")
                {
                    myState = AIState.Follow;
                }
                else
                {
                    myState = AIState.Patrol;
                }
            }
        }
    }
}
