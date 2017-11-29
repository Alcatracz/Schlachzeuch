using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class InteractableButton : MonoBehaviour {

    public UnityEvent onButtonPress;

    void OnHandHoverBegin(Hand hand)
    {
        ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, "Press F to pay Respect");
    }

    void OnHandHoverEnd(Hand hand)
    {
        ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    private void HandHoverUpdate(Hand hand)
    {
        //Trigger got pressed
        if (hand.GetStandardInteractionButtonDown())
        {
            onButtonPress.Invoke();
            ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }


}
