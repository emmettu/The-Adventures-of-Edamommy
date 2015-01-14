//using UnityEngine;
//using System.Collections;
//
//public class EnemySpawner : MonoBehaviour {
//	
//	float enemyDelay = 0;
//	float lastEnemy = 0;
//	float startTime;
//	// Use this for initialization
//	void Start () {
//		startTime = Time.time;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		lastEnemy -= Time.deltaTime;
//		if (Time.time > lastEnemy) {
//			Debug.Log("Enemy Spawned!");
//
//			GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
//			enemy.transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(-20f, 20f));
//			enemy.GetComponent<Enemy>().speed = Random.Range (1, 5);
//			enemy.GetComponent<Enemy>().damage = Random.Range (1, 3);
//			enemy.GetComponent<Enemy>().Health = 1 + ((int) ((Time.time - startTime)*0.1f));
//			//Debug.Log("Health set to: "+((Time.time -startTime)*0.1).ToString());
//			lastEnemy = Time.time + enemyDelay;
//			Debug.Log("Enemy Spawned!");
//		}
//	}
//}

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public float maxUp, maxRight;
	public float currentCooldown;
	float startTime;

	
	// Use this for initialization
	void Start () {
		maxUp = Camera.main.camera.orthographicSize;    
		maxRight = maxUp * Screen.width / Screen.height;
		currentCooldown = 0;
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (currentCooldown <= 0) {
			GameObject enemy = null;
			switch(Random.Range (0,10)) {
			case(0):
				enemy = spawnBurger ();
				break;
			case(1):
				enemy = spawnCookie();
				break;
			default:
				enemy = spawnSteak ();
				break;
			}
			switch(Random.Range (0,4)) {
			case(0):
				enemy.transform.position = new Vector3(Random.Range (-maxRight, maxRight), Random.Range (maxUp, 20f), 0);
				break;
			case(1):
				enemy.transform.position = new Vector3(Random.Range (-maxRight, maxRight), Random.Range (-maxUp, -20f), 0);
				break;
			case(2):
				enemy.transform.position = new Vector3(Random.Range (maxRight, 20f), Random.Range (-maxUp, maxUp), 0);
				break;
			case(3):
				enemy.transform.position = new Vector3(Random.Range (-maxRight, -20f), Random.Range (-maxUp, maxUp), 0);
				break;
			}
			currentCooldown = Random.Range (0, 5);
		}
		currentCooldown -= Time.deltaTime;
	}
	GameObject spawnBurger() {
		GameObject enemy = (GameObject)Instantiate(Resources.Load("Burger"));
		enemy.GetComponent<Enemy>().speed = Random.Range (1, 3);
		enemy.GetComponent<Enemy>().damage = Random.Range (1, 6);
		enemy.GetComponent<Enemy>().Health = (1 + ((int) ((Time.time - startTime)*0.1f)))*3;
		return enemy;
	}
	GameObject spawnSteak() {
		GameObject enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
		enemy.GetComponent<Enemy>().speed = Random.Range (1, 6);
		enemy.GetComponent<Enemy>().damage = Random.Range (1, 3);
		enemy.GetComponent<Enemy>().Health = 1 + ((int) ((Time.time - startTime)*0.1f));
		return enemy;
	}
	GameObject spawnCookie() {
		GameObject enemy = (GameObject)Instantiate(Resources.Load("Cookie"));
		enemy.GetComponent<Enemy>().speed = Random.Range (7, 8);
		enemy.GetComponent<Enemy>().damage = Random.Range (1, 1);
		enemy.GetComponent<Enemy>().Health = 1 + ((int) ((Time.time - startTime)*0.1f))/3;
		return enemy;
	}

}
