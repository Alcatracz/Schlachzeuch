using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScene : MonoBehaviour {
	//public int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resetscene(int scene){
		Application.LoadLevel(scene);
	}
}
