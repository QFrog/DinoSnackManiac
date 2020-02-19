using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

  private GameObject theEnemy;
  public static float score = 0;

  Text scoreDisplay;
  
  // Start is called before the first frame update
  void Start() {

    score = enemy.scoreEnemy;
    scoreDisplay = GetComponent<Text>();
  }

  // Update is called once per frame
  void FixedUpdate() {

    score = enemy.scoreEnemy;
    scoreDisplay.text = "Score:    " + score;
    //print("The score:" + score);
  }


  public void addScore() {

  }

  

}
