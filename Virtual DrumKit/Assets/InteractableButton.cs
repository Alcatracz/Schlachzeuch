using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class InteractableButton : MonoBehaviour {

    public UnityEvent onButtonPress;
}
