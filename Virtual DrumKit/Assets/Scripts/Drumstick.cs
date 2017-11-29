using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//[RequireComponent(typeof(Interactable))]
public class Drumstick : MonoBehaviour {

    //private Hand hand;
    private float stickvelocity = 1.0f;
    private Vector3 velocity = Vector3.zero;

    private VelocityEstimator ve;

    void Start()
    {
        ve = GetComponent<VelocityEstimator>();
        ve.BeginEstimatingVelocity();
    }

  

    public void Collided()
    {
        ve.FinishEstimatingVelocity();
        velocity = ve.GetVelocityEstimate();
        stickvelocity = velocity.magnitude;
        if (stickvelocity < 0)
        {
            stickvelocity = stickvelocity * -1;
        }
        Debug.Log("Velocity: " + stickvelocity);
        ve.BeginEstimatingVelocity();
    }

    public float GetStickVelocity()
    {
        return this.stickvelocity;
    }
    /*
    private void OnHandHoverBegin(Hand hand)
    {

    }

    private void OnHandHoverEnd(Hand hand)
    {

    }

    private void HandHoverUpdate(Hand hand)
    {

    }
    private void OnAttachedToHand(Hand hand)
    {
        this.hand = hand;
    }
    private void OnDetachedToHand(Hand hand)
    {

    }
    private void HandAttachedUpdate(Hand hand)
    {

    }
    private void OnHandFocusLost(Hand hand)
    {
        gameObject.SetActive(false);
    }
    private void OnHandFocusAcquired(Hand hand)
    {
        gameObject.SetActive(true);
        OnAttachedToHand(hand);
    }
    */

}
