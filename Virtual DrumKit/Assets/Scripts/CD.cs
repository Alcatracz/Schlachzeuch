using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class CD : MonoBehaviour {

	private string path;

	public string getpath(){
		return path;
	}

	public void setpath (string path){
		this.path = path;
	}

    void OnHandHoverBegin(Hand hand)
    {
        ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, "Aufheben");
    }

    void OnHandHoverEnd(Hand hand)
    {
        ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
    }
}
