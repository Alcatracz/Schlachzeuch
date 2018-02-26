using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject popup;
	public Text popuptext;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Schlagzeuglocation")
		{
			popup.SetActive (true);
			popuptext.text="Hier kannst du gleich loslegen und am Schlagzeug spielen. Solltest du noch keine Drumsticks haben befinden sich diese auf dem Sofatisch links von dir.";
			Debug.Log ("Nimm die Drumsticks mit Hilfe des Controllers auf und Spiele das Schlagzeug");
		}
		else if (other.gameObject.name == "Aufnahmelocation")
		{
			popup.SetActive (true);
			popuptext.text="Drücke den roten Knopf auf dem Mikrophone um eine Aufnahme zu beginnen und erneut um selbige zu stoppen. Hiernach solltest du dich zur Position 'Aufnahmeabspielen' teleportieren";
		}
		else if (other.gameObject.name == "Aufnahmeabspielenlocation")
		{
			popup.SetActive (true);
			popuptext.text="Wen du eine Aufnahme abgeschlossen hast erscheint auf dem Tisch vor dir eine CD die du abspielen kannst, indem du diese auf den Recorder legst";
		}
		else if (other.gameObject.name == "Perkursionsinstrumentelocation"||other.gameObject.name == "Perkursionsinstrumentelocation2")
		{
			popup.SetActive (true);
			popuptext.text="Hier gibt es noch einige weitere simple Instrumente mit denen du spielen kannst nimm sie einfach auf.";
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Schlagzeuglocation")
		{
			popup.SetActive (false);
		}
		else if (other.gameObject.name == "Aufnahmelocation")
		{
			popup.SetActive (false);
		}
		else if (other.gameObject.name == "Aufnahmeabspielenlocation")
		{
			popup.SetActive (false);
		}
		else if (other.gameObject.name == "Perkursionsinstrumentelocation"||other.gameObject.name == "Perkursionsinstrumentelocation2")
		{
			popup.SetActive (false);
		}
	}
}
