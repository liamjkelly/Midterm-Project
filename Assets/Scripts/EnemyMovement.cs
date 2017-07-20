using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float distance = 5f;
	public float moveSpeed = 5f;
	private Vector3 enemyInitPos;
	// Use this for initialization
	void Start () {
		enemyInitPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = enemyInitPos;
		newPosition.x += distance * Mathf.Cos (Time.deltaTime * moveSpeed); //changes x value of enemy vector3 back and forth
		enemyInitPos = newPosition;
	}
}
