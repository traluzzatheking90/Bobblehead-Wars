﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject[] spawnPoints;
	public GameObject alien;
	public int maxAliensOnScreen;
	public int totalAliens;
	public float minSpawnTime;
	public float maxSpawnTime;
	public int aliensPerSpawn;
	private int aliensOnScreen = 0;
	private float generatedSpawnTime = 0;
	private float currentSpawnTime = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < spawnPoints.Length; i++){
			Debug.Log("Spawn Points at startup: "+spawnPoints[i].transform.position);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		SpawnAliens();
	}

	private void SpawnAliens(){

		currentSpawnTime += Time.deltaTime;

		if(currentSpawnTime > generatedSpawnTime){
			
			currentSpawnTime = 0;
			generatedSpawnTime = Random.Range(minSpawnTime,maxSpawnTime);
			
			if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens){

				List<int> previousSpawnLocations = new List<int>();

				if (aliensPerSpawn > spawnPoints.Length){
					aliensPerSpawn = spawnPoints.Length -1;
				}
				
				aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn;

				for (int i = 0; i < aliensPerSpawn; i++){

					if (aliensOnScreen < maxAliensOnScreen){

						aliensOnScreen += 1;
						int spawnPoint = - 1;

						while (spawnPoint == -1){

							int randomNumber = Random.Range(0, spawnPoints.Length -1);

							if(!previousSpawnLocations.Contains(randomNumber)){

								previousSpawnLocations.Add(randomNumber);
								spawnPoint = randomNumber;
							}
						}

						GameObject spawnLocation = spawnPoints[spawnPoint];
						GameObject newAlien = Instantiate(alien) as GameObject;
						newAlien.transform.position = spawnLocation.transform.position;

						Debug.Log("Spawn Points number: "+spawnPoint+" at location "+spawnLocation.transform.position);

						// Add a target to Alien's NavMeshAgent. The target is the player
						Alien alienScript = newAlien.GetComponent<Alien>();
						alienScript.target = player.transform;
						
						// Alien rotate towards the hero right
						Vector3 targetRotation = new Vector3(player.transform.position.x, newAlien.transform.position.y, player.transform.position.z);
						newAlien.transform.LookAt(targetRotation);
					}
				}
			}
		}
	}
}
