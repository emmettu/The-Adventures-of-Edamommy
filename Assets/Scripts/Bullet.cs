using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float lifetime;
	public float deathtime;

	// Use this for initialization
	void Start () {
		lifetime = 1;
		deathtime = Time.time + lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > deathtime) {
			Destroy (this.gameObject);
		}
	}
}
