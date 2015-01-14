using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int speed;
	Vector3 PlayerPosition;
	GameObject player;
	public int Health;
	public int damage;

	// Use this for initialization
	void Start () {
//		speed = 2;
//		Health = 5;
//		damage = 1;
		player = GameObject.Find ("player");
		PlayerPosition = player.transform.position;
		Debug.Log ("Found Player!");
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Destroy (gameObject);
			player.GetComponent<Movement>().score += 10;

		}
		if (player) {
			PlayerPosition = player.transform.position;
			transform.position = Vector3.MoveTowards (transform.position, PlayerPosition, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Enemy HIT!");
		if (collision.gameObject.name == "Bullet(Clone)") { 
			Destroy (collision.gameObject);
			Health -= player.GetComponent<Movement>().damage;
		}
	}
}
