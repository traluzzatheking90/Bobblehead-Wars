using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject followTarget;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(followTarget != null){
			// Lerp = Linear Interpolator(start position, end position, number between 0 and 1) -> returns a point between two vectors determinate by last number
			transform.position = Vector3.Lerp(transform.position,followTarget.transform.position,Time.deltaTime * moveSpeed);
		}
	}
}
