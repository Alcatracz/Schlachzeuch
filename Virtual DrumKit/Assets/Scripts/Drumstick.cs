using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//[RequireComponent(typeof(Interactable))]
public class Drumstick : MonoBehaviour
{
    [EnumFlags] 
    public Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags;

    private Coroutine routine;
    private Vector3 direction;

    public string attachmentPoint; 
    [Tooltip("When detaching the object, should it return to its original parent?")] 
    public bool restoreOriginalParent = false;

    private CapsuleCollider ownCollider;
    private Rigidbody rb;
    private Hand hand;
    private float stickvelocity = 1.0f;
    private Vector3 velocity = Vector3.zero;

    private VelocityEstimator ve;

    void Start()
    {
        ownCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        ve = GetComponent<VelocityEstimator>();
        ve.BeginEstimatingVelocity();
        BeginDirection();
    }

  

    public void Collided()
    {
        ve.FinishEstimatingVelocity();
        FinishDirection();
        velocity = ve.GetVelocityEstimate();
        stickvelocity = velocity.magnitude;
        if (stickvelocity < 0)
        {
            stickvelocity = stickvelocity * -1;
        }
        Debug.Log("Velocity: " + stickvelocity);
        ve.BeginEstimatingVelocity();
        BeginDirection();
        hand.controller.TriggerHapticPulse(400);
        
    }

    public Vector3 GetDirection()
    {
        return this.direction;
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
            hand.AttachObject(gameObject,attachmentFlags,attachmentPoint);
            ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }
    void Update()
    {
        if (hand != null)
        {
            if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                hand.DetachObject(gameObject,restoreOriginalParent);
                ownCollider.isTrigger = false;
                rb.isKinematic = false;
                rb.useGravity = true;
                
            }
        }
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

    public void BeginDirection()
    {
        FinishDirection();

        routine = StartCoroutine(DirectionCoroutine());
    }


    //-------------------------------------------------
    public void FinishDirection()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
    }

    private IEnumerator DirectionCoroutine()
    {   
        Vector3 previousPosition = transform.position;

        while (true)
        {
            yield return new WaitForEndOfFrame();

            direction = transform.position - previousPosition;


            previousPosition = transform.position;   
        }

    }



    }
