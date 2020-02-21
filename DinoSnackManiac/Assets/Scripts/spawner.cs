using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

  //Enemy
  public GameObject cookieEnemyPrefab;
  public GameObject cookieEnemyPrefab1;
  public GameObject cookieEnemyPrefab2;

  public GameObject spawnerPrefab;
  //Spawner Variables
  private float waveGrowth = 1f;
  private float enemiesToSpawn;
  public float timeUntilSpawn = 0f;
  public int spawnCooldown = 10;
  private int rand = 1;

  public float stagger = .3f;

  private int scoreMultiplier = 500;
  //private float localScore = 0f;

  //random number at start
  private void Start() {
    int rand = Random.Range(1, 5);
  }


  // Update is called once per frame
  private void Update() {
    rand = Random.Range(0, 5);

    timeUntilSpawn += Time.deltaTime;
   
    //spawns cookies and establishes cooldown
    if (timeUntilSpawn >= spawnCooldown) {
      StartCoroutine(cookieSpawner());
      //spawnCookie();
      timeUntilSpawn = 0;
      waveGrowth += (.05f + (GameManager.score/10000));
     // print("WaveGro: " + waveGrowth);
      if (waveGrowth >= 10) {
        waveGrowth = 10;
        print("Wave cap");
        print(waveGrowth);
      }
      
    }

  }






  //private float n = 0;

  //private void spawnCookie() {

  //  Vector3 spawnerPos = transform.position + new Vector3(rand, rand, 0);

  //  //Sets up spawn range and spawning of a single enemy
  //  // Vector3 pos = new Vector3(Random.Range(rand, rand), Random.Range(rand, rand), 0);
    
  //  //Spawning a random amount of enemies
  //  for (enemiesToSpawn = (/*rand **/ waveGrowth); enemiesToSpawn >= 0; enemiesToSpawn--) {

  //    GameObject spawner = Instantiate(cookieEnemyPrefab, spawnerPos, Quaternion.identity) as GameObject;
  //  }

  //}

  IEnumerator cookieSpawner() {

    Vector3 spawnerPos = transform.position + new Vector3(Random.Range(1,2), Random.Range(1,2), 0);

    for (enemiesToSpawn = (waveGrowth /** scoreMultiplier*/); enemiesToSpawn >= 0; enemiesToSpawn--) {
      yield return new WaitForSeconds(stagger);
      if (Random.Range(1, 3) == 1) {
        GameObject spawner = Instantiate(cookieEnemyPrefab, spawnerPos, Quaternion.identity) as GameObject;
      }
      else if (Random.Range(1, 3) == 1) {
        GameObject spawner = Instantiate(cookieEnemyPrefab1, spawnerPos, Quaternion.identity) as GameObject;
      }
      else {
        GameObject spawner = Instantiate(cookieEnemyPrefab2, spawnerPos, Quaternion.identity) as GameObject;
      }
    }
    // yield return new WaitForSeconds(stagger);
    //print(Fibonacci(waveGrowth));
  }




  public static int Fibonacci(int n) {
    int a = 0;
    int b = 1;
    // In N steps compute Fibonacci sequence iteratively.
    for (int i = 0; i < n; i++) {
      int temp = a;
      a = b;
      b = temp + b;
    }
    return a;
  }




  //DO NOT USE
  public float factorial(float n) {
    if (n == 0) return (1);

    return (n * factorial(n - 1));
  }




}
