using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchHandler : MonoBehaviour {

	public Vector3 velocity;
	private float magnitude;
	private AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		magnitude = velocity.magnitude;
		audiosource.volume = 1 * magnitude;
	}
}
