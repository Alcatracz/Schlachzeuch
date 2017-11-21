using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Михаилплеть : MonoBehaviour {

	public GameObject goforposition;
	private Hand hand;
	private bool atached;
	private GameObject cd;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (atached&&hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)) {
			cd.transform.position = goforposition.transform.position;
			cd.transform.rotation = goforposition.transform.rotation;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "CD") {
			other.gameObject.GetComponent<AudioSource> ().Play();
			atached = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "CD") {
			other.gameObject.GetComponent<AudioSource> ().Pause();
			atached = false;
		}
	}


}
