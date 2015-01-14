using UnityEngine;
using System.Collections;

public class Damage : Pickup {

	override public void activate(GameObject player) {
		Debug.Log ("Activating!");
		player.GetComponent<Movement> ().damage += 1;
	}
}
