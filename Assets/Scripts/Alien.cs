using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour {

	// Alien target
	public Transform target;
	private NavMeshAgent agent;

	//Update the path evrry navigationUpdate 
	public float navigationUpdate;
	private float navigationTime = 0;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			navigationTime += Time.deltaTime;
			if(navigationTime > navigationUpdate){
				agent.destination = target.position;
				navigationTime = 0;
			}
		}
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other){
		Destroy(gameObject);
	}
}
