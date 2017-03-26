using UnityEngine;
using UnityEngine.AI;

public class Alien : MonoBehaviour {

	// Alien target
	public Transform target;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = target.position;
	}
}
