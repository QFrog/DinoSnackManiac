using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public GameObject theEnemy;
  public static float score = 0;
  
  
  // Start is called before the first frame update
  void Start() {

    score = enemy.scoreEnemy;
  }

  // Update is called once per frame
  void Update() {

    score = enemy.scoreEnemy;
    //print("The score:" + score);
  }


  public void addScore() {

  }

}
