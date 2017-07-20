using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	float max, min;

	// Use this for initialization
	void Start () {
		max = transform.position.x + 3;
		min = transform.position.x - 3;
	}
	
	// Update is called once per frame
	void Update () {
		//enemies oscillate between -3 and +3 on the x axis from their starting position
		transform.position = new Vector3(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y, transform.position.z);
	}
}
