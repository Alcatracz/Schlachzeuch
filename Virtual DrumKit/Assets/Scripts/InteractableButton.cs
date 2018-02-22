 using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class InteractableButton : MonoBehaviour {

    public UnityEvent onButtonPress;
    public string beginHintText = "Start Recording";
    public string endHintText = "End Recording";

    //public AudioClip buttonPressSound;
    private AudioSource audioSource;
    private bool isRecording = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnHandHoverBegin(Hand hand)
    {
        ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, beginHintText);
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
            //ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
            ToggleRecording();
           
            audioSource.Play();
        }

        if (isRecording)
        {
            ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, endHintText);
        }
        else
        {
            ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, beginHintText);

        }

    }
    private void ToggleRecording()
    {
        if (isRecording)
        {
            isRecording = false;
        }
        else
        {
            isRecording = true;
        }
    }
}


