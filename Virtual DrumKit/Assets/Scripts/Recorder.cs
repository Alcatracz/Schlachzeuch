using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Recorder : MonoBehaviour {

    private Hand hand;
    public bool recording=false;
    private int counter=0;

    private void OnHandHoverBegin(Hand hand)
    {
    }

    private void OnHandHoverEnd(Hand hand)
    {
    }

    private void HandHoverUpdate(Hand hand)
    {
        recording = hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip);
            
    }
    private void OnAttachedToHand(Hand hand)
    {
    }
    private void OnDetachedToHand(Hand hand)
    {

    }
    private void HandAttachedUpdate(Hand hand)
    {

    }
    private void OnHandFocusLost(Hand hand)
    {
    }
    private void OnHandFocusAcquired(Hand hand)
    {
    }

    public bool getisrecording() {
        return recording;
    }
}
