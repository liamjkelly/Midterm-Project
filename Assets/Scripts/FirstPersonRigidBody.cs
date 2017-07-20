using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonRigidBody : MonoBehaviour {

	public float mouseSensitivty = 100f;
	public float moveSpeed = 10f;
	public Text myText;
	Vector3 inputVector; //this variable passes data from Update > FixedUpdate
	Rigidbody rb;
	float mouseY; //accumulate mouseY data so we can clamp it later
	private Vector3 initPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //cache reference to Rigidbody
		initPos = transform.position;
	}
	
	// Update is called once per frame
	//always put input/rendering in regular update
	void Update () {
		//keyboard movement
		inputVector.x = Input.GetAxis ("Horizontal");
		inputVector.y = -0.5f;
		inputVector.z = Input.GetAxis ("Vertical"); 

		/*
		//mouse look
		transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime* mouseSensitivty, 0f);
		mouseY -= Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivty;
		mouseY = Mathf.Clamp (mouseY, -60f, 60f); //clamp vertical mouse look
		Camera.main.transform.localEulerAngles = new Vector3(mouseY, 0f, 0f); //apply up-down movement

		//hide the mouse cursor
		if (Input.GetMouseButtonDown(0)) { //0=left click, 1=right click, 2=middle click
			Cursor.lockState = CursorLockMode.Locked; //locks cursor to middle of screen
			Cursor.visible = false; //hides the cursor
		}*/

		//code to jump
		if (Input.GetKeyDown(KeyCode.Space)) {
			inputVector.y += 3f;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			inputVector.y -= 3f;
		}
			
	}
	//FixedUpdate runs on a fixed interval with PhysX
	//always put physics code in FixedUpdate
	void FixedUpdate () {
		//convert inputVector from local space to world space
		//"transform.right" is the capsule's current "right"
		//also see: "transform.TransformDirection()"
		Vector3 worldVector = transform.right * inputVector.x + transform.forward * inputVector.z + transform.up * inputVector.y;

		//AddForce is good for movement that IS NOT walking
		//rb.AddForce (worldVector * moveSpeed, ForceMode.Acceleration); //actually applies the force now

		//set velocity directly = is good for walking
		rb.velocity = worldVector * moveSpeed;
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "fangirl") {
			transform.position = initPos;
		} else if (col.gameObject.tag == "stage") {
			myText.text = "NOW YOU CAN RAGE";
		}
	}
}
