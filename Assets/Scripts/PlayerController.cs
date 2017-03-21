using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 50.0f;
	private CharacterController characterController;
	public Rigidbody head;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		characterController.SimpleMove(moveDirection * moveSpeed);
	}


	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// It's called at consistent intervarls and not subject to frame rate. Any phisic operation
	/// should be here (as we make on Rigid body)
	void FixedUpdate(){
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		if (moveDirection == Vector3.zero){
			//TODO
		}else{
			head.AddForce(transform.right * 150, ForceMode.Acceleration);
		}
	}
}
