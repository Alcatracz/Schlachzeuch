using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Drumstick : MonoBehaviour {

    private Hand hand;

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


}
