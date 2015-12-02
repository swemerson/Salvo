using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;

	private Vector3 movement;
	private float speed;
	private Rigidbody2D rb2d;
	private float nextFire;

	void Start () 
	{
		speed = 35f;
		rb2d = GetComponent<Rigidbody2D>();
		fireRate = 0.07f;
	}

	void Update () 
	{
		// Rotate player to mouse position
		Vector3 mousePos = Input.mousePosition;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;	
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		// Movement (WASD or Arrows)
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		movement.Set(x, y, 0f);
		movement = movement.normalized * speed * Time.smoothDeltaTime;
		rb2d.MovePosition(transform.position + movement);

		// Shoot (Mouse 1)
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}
}
