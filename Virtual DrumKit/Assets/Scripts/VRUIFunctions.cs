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

	public void starttheGamewTutorial(){
		SceneManager.LoadScene ("FinalwithTutorial");
	}

	public void quittheGame(){
		Application.Quit();
	}

	public void quittoMainMenu(){
		SceneManager.LoadScene ("UI");
	}

}

