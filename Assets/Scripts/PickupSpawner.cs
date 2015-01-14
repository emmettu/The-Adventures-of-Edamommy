using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

	public float maxUp, maxRight;
	public float currentCooldown;

	// Use this for initialization
	void Start () {
		maxUp = Camera.main.camera.orthographicSize;    
		maxRight = maxUp * Screen.width / Screen.height;
		currentCooldown = Random.Range (0, 15);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCooldown <= 0) {
			int pickUpCode = Random.Range (1,11);
			GameObject pickup = null;
			if(pickUpCode.Equals (10)) {
				pickup = (GameObject)Instantiate(Resources.Load("Damage"));
			}
			else if(pickUpCode.Equals (9)) {
				pickup = (GameObject)Instantiate(Resources.Load("ShotSpeed"));
			}
			else {
				pickup = (GameObject)Instantiate(Resources.Load("Health"));
			}
			pickup.transform.position = new Vector3(Random.Range (-maxRight, maxRight), Random.Range (-maxUp, maxUp), 0);
			currentCooldown = Random.Range (0, 15);
		}
		currentCooldown -= Time.deltaTime;
	}
}
