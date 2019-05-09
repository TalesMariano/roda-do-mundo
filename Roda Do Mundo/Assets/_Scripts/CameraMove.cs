using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	//move only x

	public Transform target;

	Vector3 basePos;

	public float speed = 1;

	void Start () {
		basePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, speed*Time.deltaTime), basePos.y,basePos.z);
	}
}
