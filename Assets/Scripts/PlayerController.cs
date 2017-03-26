using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 50.0f;
	private CharacterController characterController;
	public Rigidbody head;
	public LayerMask layerMask;
	private Vector3 currentLookTarget = Vector3.zero;


	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		// Move
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		characterController.SimpleMove(moveDirection * moveSpeed);
	}


	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// It's called at consistent intervarls and not subject to frame rate. Any phisic operation
	/// should be here (as we make on Rigid body)
	void FixedUpdate(){

		MouseMovementController();
	}

	private void MouseMovementController(){

		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

		if (moveDirection == Vector3.zero){
			//TODO
		}else{
			head.AddForce(transform.right * 150, ForceMode.Acceleration);
		}
		RaycastHit hit; // Can contain an object
		//Create a ray follow the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin,ray.direction * 1000, Color.green);
		if (Physics.Raycast(ray,out hit,1000,layerMask,QueryTriggerInteraction.Ignore)){
			if(hit.point != currentLookTarget){
				currentLookTarget = hit.point;
			}
			Vector3 targetPosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);
			Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
			transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime * 10.0f);
		}
	}
}
