using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//[RequireComponent(typeof(Interactable))]
public class AccesMenu : MonoBehaviour
{

	public Hand hand;
	public GameObject ui;


	private void OnHandHoverBegin(Hand hand)
	{
	}

	private void OnHandHoverEnd(Hand hand)
	{
	}

	private void HandHoverUpdate(Hand hand)
	{

	}

	void Update()
	{
			if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu))
			{
			ui.SetActive (!ui.activeSelf);
			}
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


}
