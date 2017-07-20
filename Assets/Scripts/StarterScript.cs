using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterScript : MonoBehaviour {

	public Text myText;
	
	// Update is called once per frame
	void Update () {
		//makse starter text disappear
		if (Input.GetKeyDown(KeyCode.Return)) {
			myText.text = "";
		}
	}
}
