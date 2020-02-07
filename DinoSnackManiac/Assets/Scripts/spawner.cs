using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

  //Enemy
  public GameObject cookieEnemyPrefab;
  //Spawner Variables
  private int waveGrowth = 1;
  private int enemiesToSpawn;
  public float timeUntilSpawn = 0;
  public float spawnCooldown = 1;
  private int rand = 1;

  //random number at start
  private void Start() {
    int rand = Random.Range(1, 5);
  }


  // Update is called once per frame
  void Update() {
    rand = Random.Range(1, 5);
    timeUntilSpawn -= Time.deltaTime;

    //spawns cookies and establishes cooldown
    if (timeUntilSpawn <= 5) {
      spawnCookie();
      timeUntilSpawn = spawnCooldown;
    }

  }








  private void spawnCookie() {

    //Sets up spawn range and spawning of a single enemy
    Vector3 pos = new Vector3(Random.Range(rand, rand), Random.Range(rand, rand), 0);

    //Spawning a random amount of enemies
    for (enemiesToSpawn = (rand * waveGrowth); enemiesToSpawn >= 0; enemiesToSpawn--) {
      GameObject spawner = Instantiate(cookieEnemyPrefab, pos, Quaternion.identity) as GameObject;
    }

  }


}
