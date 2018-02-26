using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class NewDrumStick : MonoBehaviour {

    [EnumFlags]
    public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;
    public string attachmentPoint;
    private Rigidbody rb;
    private HingeJoint hj;
    private Hand hand;

    private CapsuleCollider ownCollider;
    private float stickvelocity = 1.0f;
    private Vector3 velocity = Vector3.zero;

    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;

    private Quaternion m_StickTargetRot;
    private VelocityEstimator ve;

    // Use this for initialization

    void Start () {
        ownCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        ve = GetComponent<VelocityEstimator>();
        hj = GetComponent<HingeJoint>();
        print("HINGE JOINT: "+hj.name);
        hj.connectedBody = hand.GetComponent<Rigidbody>();
        print("Hand Position : x"+hand.transform.position.x+", y"+hand.transform.position.y+", z"+hand.transform.position.z);
        transform.position = hand.transform.position; 

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
        
        hand.controller.TriggerHapticPulse(400);

    }

  

    public float GetStickVelocity()
    {
        return this.stickvelocity;
    }

    private void OnHandHoverBegin(Hand hand)
    {
        ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, "Pick Up");
    }

    private void OnHandHoverEnd(Hand hand)
    {
        ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown())
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            ownCollider.isTrigger = true;
            hand.AttachObject(gameObject, attachmentFlags, attachmentPoint);
            ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }
    void Update()
    {
        if (hand != null)
        {
            if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                hand.DetachObject(gameObject, false);
                ownCollider.isTrigger = false;
            }
        }
    }


    private void OnAttachedToHand(Hand hand)
    {
        this.hand = hand;
        print("Attached");    
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

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

}
