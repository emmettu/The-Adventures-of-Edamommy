using UnityEngine;
using System.Collections;

public class Health : Pickup {

	override public void activate(GameObject player) {
		Debug.Log ("Activating!");
		player.GetComponent<Movement> ().Health += 1;
	}
}
