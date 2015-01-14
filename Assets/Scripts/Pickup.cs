using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	int lifetime = 2;
	float currentLife = 0;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		currentLife += Time.deltaTime;
		if (((int)currentLife) > lifetime) {
			Destroy (this.gameObject);
		}
	}

	public virtual void activate (GameObject player){}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "player") {
			activate(other.gameObject);
			Destroy (gameObject);
		}
	}
}
