using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HitClave : MonoBehaviour {

    private float stickvelocity = 1.0f;
    private Vector3 velocity = Vector3.zero;
    private VelocityEstimator ve;
    
    void Start () {
        ve = GetComponent<VelocityEstimator>();
        ve.BeginEstimatingVelocity();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Collided()
    {
        print("Collideed");
        ve.FinishEstimatingVelocity();
        velocity = ve.GetVelocityEstimate();
        stickvelocity = velocity.magnitude;
        if (stickvelocity < 0)
        {
            stickvelocity = stickvelocity * -1;
        }
        ve.BeginEstimatingVelocity();
    }

    public float GetStickVelocity()
    {
        print("GetStickVelocity: "+stickvelocity);
        return this.stickvelocity;
    }
}
