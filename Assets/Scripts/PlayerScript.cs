using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	private Vector3 movement;
	private float speed;
	private Rigidbody2D rb2d;

	void Start () 
	{
		speed = 25f;
		rb2d = GetComponent<Rigidbody2D>();
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

		// Movement
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		movement.Set(x, y, 0f); // z was 0
		movement = movement.normalized * speed * Time.deltaTime;
		rb2d.MovePosition(transform.position + movement);
	}
}
