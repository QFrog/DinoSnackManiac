using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

  //Enemy
  public GameObject cookieEnemyPrefab;
  public GameObject spawnerPrefab;
  //Spawner Variables
  private int waveGrowth = 1;
  private int enemiesToSpawn;
  public float timeUntilSpawn = 0;
  public float spawnCooldown = 30;
  private int rand = 1;

  //random number at start
  private void Start() {
    int rand = Random.Range(1, 2);
  }


  // Update is called once per frame
  private void Update() {
    rand = Random.Range(1, 2);

    timeUntilSpawn += Time.deltaTime;
   
    //spawns cookies and establishes cooldown
    if (timeUntilSpawn >= spawnCooldown) {
      spawnCookie();
      timeUntilSpawn = 0;
    }
    
    
  }








  private void spawnCookie() {

    Vector3 spawnerPos = transform.position + new Vector3(rand, rand, 0);
 
    //Sets up spawn range and spawning of a single enemy
    // Vector3 pos = new Vector3(Random.Range(rand, rand), Random.Range(rand, rand), 0);

    //Spawning a random amount of enemies
    for (enemiesToSpawn = (rand * waveGrowth); enemiesToSpawn >= 0; enemiesToSpawn--) {
      GameObject spawner = Instantiate(cookieEnemyPrefab, spawnerPos, Quaternion.identity) as GameObject;
    }

  }


}
