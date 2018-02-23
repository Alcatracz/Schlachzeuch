using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class fileexplorer : MonoBehaviour {

	string path;

	public void OpenExplorer(){
		
         path = EditorUtility.OpenFolderPanel("Choose", "", "");

}
}
