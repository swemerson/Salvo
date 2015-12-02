using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	private Transform target;
	private Vector3 cameraTarget;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		cameraTarget = new Vector3 (target.position.x, target.position.y, target.position.z - 10);
		transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 6);
	}
}
