using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRUIFunctions : MonoBehaviour {

	public void hardRestarttheGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void starttheGame(){
		SceneManager.LoadScene ("Final");
	}

	public void quittheGame(){
		Application.Quit();
	}

}

