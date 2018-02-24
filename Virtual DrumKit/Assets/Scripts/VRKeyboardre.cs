using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRKeyboardre : MonoBehaviour {

	public Text key;
	string keyvalue=null;
	string result=null;
	public Text inputfield;



	public void getText(){
		if (inputfield.text.Length <= 35) {
			keyvalue = key.text;
			result = keyvalue;
			inputfield.text += result;
		}

	}

	public void backspace(){
		if (inputfield.text.Length >= 1) {
			inputfield.text = inputfield.text.Substring (0, inputfield.text.Length - 1);
		}
	}

	public void clearall(){
		inputfield.text = "";
	}

	public void space(){
		if (inputfield.text.Length <= 35) {
			inputfield.text += " ";
		}
	}
}
