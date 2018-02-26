using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Schellenkranz : MonoBehaviour {
    Rigidbody rb;
    AudioSource ass;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        ass = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.magnitude > 0)
        {
           // ass.loop = true;
            ass.Play(); 
        }
        else
        {
            //ass.loop = false;
            //ass.Stop();
        }


	}


}
