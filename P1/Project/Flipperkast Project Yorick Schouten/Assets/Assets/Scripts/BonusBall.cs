using UnityEngine;
using System.Collections;

public class BonusBall : MonoBehaviour {

    public Vector3 ballPos;
    public ParticleSystem bonuspc;

    public void Start()
    {
        ballPos = transform.position;
    }

    public void ExtraBall()
    {
        Instantiate(Resources.Load("BonusBall"), ballPos, Quaternion.identity);
        bonuspc.Emit(120);
    }
}
