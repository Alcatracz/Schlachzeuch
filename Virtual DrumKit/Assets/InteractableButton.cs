using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class InteractableButton : MonoBehaviour {

    public UnityEvent onButtonPress;
    public string hintText = "Press F to pay respect";

    void OnHandHoverBegin(Hand hand)
    {
        ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, hintText);
    }

    void OnHandHoverEnd(Hand hand)
    {
        ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    private void HandHoverUpdate(Hand hand)
    {
        //Trigger got pressed
        if (hand.GetStandardInteractionButtonDown() && onButtonPress != null)
        {
            onButtonPress.Invoke();
            ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }


}
