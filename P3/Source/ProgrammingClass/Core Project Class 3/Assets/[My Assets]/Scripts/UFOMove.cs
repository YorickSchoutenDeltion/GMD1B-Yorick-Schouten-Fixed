using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour {

    public Animator anim;

	void Update()
    {
        SetFloats();
	}

    void SetFloats()
    {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }
}
