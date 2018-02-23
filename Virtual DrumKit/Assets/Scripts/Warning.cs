using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour {
	public Text inputfield;
	public GameObject warning;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		if (inputfield.text.Length >= 35) {
			warning.SetActive (true);
		} else {
			warning.SetActive (false);
		}
	}
}
