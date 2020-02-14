using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public GameObject theEnemy;
  public float score = 0;
  public bool enemyHit_ = false;
  
  // Start is called before the first frame update
  void Start() {
    

    //GameObject theEnemy = GameObject.Find("enemyScripts");

    //enemy eHit = theEnemy.GetComponent<enemy>();
    ////score += eScore.scoreEnemy;
    //enemyHit_ = eHit.enemyHit;

  }

  // Update is called once per frame
  void Update() {
    //score += scoreEnemy;
    //if (enemyHit_) {
    //  score += 100;
    //  print("The score:" + score);
    //}
  }


  public void addScore() {

  }

}
