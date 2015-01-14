using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int score = (int)PlayerPrefs.GetFloat ("score");
		guiText.text = "You Died With " + score.ToString () + " Points\nPress R to Restart";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)) {
			Application.LoadLevel ("Edamommy");
		}
	}
}
