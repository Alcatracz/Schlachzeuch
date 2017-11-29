using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emite : MonoBehaviour {

	private bool recording = false;
	private Renderer renderer;
	private Material material;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		material = renderer.material;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggle (){
		if (recording == false) {
			recording = true;
			material.EnableKeyword ("_EMISSION");
		} else {
			recording = false;
			material.DisableKeyword("_EMISSION");
		}
	}
}
