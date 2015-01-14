using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int speed;
	public int bulletSpeed;
	public Vector3 pos;
	public float leftBound, rightBound, topBound, bottomBound;
	public float fireCooldown;
	public float nextBullet;
	public int damage;
	public int Health;
	public float score;
	public float redFlash = 0.4f;
	public float resetColor;
	public float invulnerAbilityTime = 20;
	public float currentVulnerability;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.speed = 10;
		this.bulletSpeed = 100;
		this.damage = 1;
		this.fireCooldown = 0.2f;
		this.Health = 10;

		this.nextBullet = Time.time;

		pos = transform.position;

		float vertExtent = Camera.main.camera.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		leftBound = -horzExtent;
		rightBound = horzExtent;
		bottomBound = -vertExtent;
		topBound = vertExtent;

		resetColor = Time.time;
		currentVulnerability = Time.time;
		invulnerAbilityTime = 1;

	}
	
	// Update is called once per frame
	void Update() {
		movePlayer ();
		if (Time.time > this.nextBullet) {
			firePlayer ();
			nextBullet = Time.time + fireCooldown;
		}
		if (Health <= 0) {
			Destroy(this.collider2D);
			Destroy(this.renderer);
			PlayerPrefs.SetFloat("score", score);
			PlayerPrefs.Save();
			Application.LoadLevel ("Restart");

		}

		score += Time.deltaTime;
		if (Time.time > resetColor) {
			renderer.material.SetColor("_Color", Color.white);
		}
	}
	void OnGUI() {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 20;

		GUI.Label(new Rect(970f, 10f, 100f, 100f), "Health: "+ Health.ToString(), myStyle);
		GUI.Label(new Rect(10f, 10f, 100f, 100f), "Score: "+((int) score).ToString(), myStyle);

	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Player Hit");
		if (Time.time < currentVulnerability) { Debug.Log ("No damage"); }
		else if (collision.gameObject.tag == "enemy") { 
			Health -= collision.gameObject.GetComponent<Enemy>().damage;
			Debug.Log("HealthDown!");
			renderer.material.SetColor("_Color", Color.red);
			resetColor = Time.time + redFlash;
			currentVulnerability = Time.time + invulnerAbilityTime;
		}
	}
	void movePlayer () {
		if(Input.GetKey(KeyCode.UpArrow)) {
			this.rigidbody2D.AddForce(Vector2.up*speed);
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			this.rigidbody2D.AddForce(-(Vector2.up*speed));

		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			this.rigidbody2D.AddForce(-(Vector2.right*speed));

		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			this.rigidbody2D.AddForce(Vector2.right*speed);

		}
		pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
		pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
		transform.position = pos;

	}
	void firePlayer() {
		if(Input.GetKey(KeyCode.A)) {
			GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet")); ;
			bullet.transform.position = this.transform.position - transform.right;
			bullet.rigidbody2D.AddForce(-Vector2.right*bulletSpeed);
		}
		else if(Input.GetKey(KeyCode.D)) {
			GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet")); ;
			bullet.transform.position = this.transform.position + transform.right;
			bullet.rigidbody2D.AddForce(Vector2.right*bulletSpeed);
		}
		else if(Input.GetKey(KeyCode.W)) {
			GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet")); ;
			bullet.transform.position = this.transform.position + transform.up;
			bullet.rigidbody2D.AddForce(Vector2.up*bulletSpeed);
		}
		else if(Input.GetKey(KeyCode.S)) {
			GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet")); ;
			bullet.transform.position = this.transform.position - transform.up;
			bullet.rigidbody2D.AddForce(-Vector2.up*bulletSpeed);
		}
	}
}