using UnityEngine;
using System.Collections;

public class ShotSpeed : Pickup {

	override public void activate(GameObject player) {
		player.GetComponent<Movement> ().fireCooldown -= 0.01f;
	}
}
