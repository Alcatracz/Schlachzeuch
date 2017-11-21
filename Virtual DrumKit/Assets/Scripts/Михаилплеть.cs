using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Михаилплеть : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "CD") {
			other.gameObject.GetComponent<AudioSource> ().Play();
			other.gameObject.GetComponent<Rigidbody>().useGravity=false;
		}
	}

	void onTriggerExit(Collider other){
		if (other.gameObject.tag == "CD") {
			other.gameObject.GetComponent<AudioSource> ().Pause();
			other.gameObject.GetComponent<Rigidbody>().useGravity=true;
		}
	}


}
