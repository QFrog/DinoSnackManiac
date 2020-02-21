using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


  public float moveSpeed = 0.5f;
  public LayerMask collisionLayer;

  private BoxCollider2D boxCollider;
  private Rigidbody2D rigid;
  private float inverseMoveSpeed; //used for efficiency 
  private float counter = 0;

  public GameObject player;
  public GameObject theEnemy;
  private SpriteRenderer enemySprite;
  public Vector3 playerPos;
  public static int scoreEnemy = 0;

  public bool enemyHit = false;
  private float timeCount = 0f;


  //Protected virtual functions can be overriden by inheriting classes
  protected virtual void Start() {

    //getting component references
    boxCollider = GetComponent<BoxCollider2D>();
    rigid = GetComponent<Rigidbody2D>();
    enemySprite = GetComponent<SpriteRenderer>();
    //storing reciprocal of move speed we can use it to multiply instead of dividing (efficient)
    inverseMoveSpeed = 1f / moveSpeed;

    // GameObject thePlayer = GameObject.Find("PlayerDino");
    //PlayerController playerL = thePlayer.GetComponent<PlayerController>();
    //playerPos = playerL.playerLocation;

  }



  public void FixedUpdate() {


    if (theEnemy.transform.position.x <= playerPos.x) {
      //print("Player Location" + playerPos.y);
      //print("Enemy Location" + theEnemy.transform.position.y);
      theEnemy.transform.localRotation = Quaternion.Euler(0, 0, 0);
      enemySprite.flipX = true;
    }
    else {
      theEnemy.transform.localRotation = Quaternion.Euler(180, 180, 0);
      enemySprite.flipX = false;
    }

    //transform.rotation = Quaternion.LookRotation(moveVec, Vector3.back);

    //gets player location
    //finds the object named PlayerDino
    GameObject thePlayer = GameObject.Find("PlayerDino");

    PlayerController playerL = thePlayer.GetComponent<PlayerController>();
    playerPos = playerL.playerLocation;
    //calls movements
    StartCoroutine(movement(playerPos));
    //calls the standup function
    standUp();

    //increases enemy movespeed with score
    if (GameManager.score >= 2000 && GameManager.score < 3000) {
      moveSpeed = 1.15f;
    }
    if (GameManager.score >= 3000 && GameManager.score < 4000) {
      moveSpeed = 1.25f;
    }
    else if (GameManager.score >= 4000 && GameManager.score < 5000) {
      moveSpeed = 1.35f;
    }
    else if (GameManager.score >= 5000 && GameManager.score < 6000) {
      moveSpeed = 1.45f;
    }
    else if (GameManager.score >= 6000 && GameManager.score < 7000) {
      moveSpeed = 1.55f;
    }
    else if (GameManager.score >= 7000 && GameManager.score < 8000) {
      moveSpeed = 1.6f;
    }
    else if (GameManager.score >= 8000 && GameManager.score < 9000) {
      moveSpeed = 1.65f;
    }
    else if (GameManager.score >= 9000 && GameManager.score < 10000) {
      moveSpeed = 1.75f;
    }
    else if (GameManager.score >= 10000 && GameManager.score < 12000) {
      moveSpeed = 2f;
    }
    else if (GameManager.score >= 12000 && GameManager.score < 16000) {
      moveSpeed = 2.25f;
    }
    else if (GameManager.score >= 16000 && GameManager.score < 25000) {
      moveSpeed = 2.35f;
    }
    else if (GameManager.score >= 25000 && GameManager.score < 30000) {
      moveSpeed = 2.45f;
    }
    else if (GameManager.score >= 30000 && GameManager.score < 50000) {
      moveSpeed = 2.55f;
    }
    else if (GameManager.score >= 50000 && GameManager.score < 70000) {
      moveSpeed = 2.65f;
    }
    else if (GameManager.score >= 70000 && GameManager.score < 80000) {
      moveSpeed = 2.75f;
    }
    else if (GameManager.score >= 80000 && GameManager.score < 100000) {
      moveSpeed = 2.85f;
    }
    else if (GameManager.score >= 80000 && GameManager.score < 100000) {
      moveSpeed = 2.95f;
    }
    else if (GameManager.score >= 100000) {
      moveSpeed = 3f;
    }



  }

  //keeps players and enemies from spinning
  private void standUp() {
    transform.localEulerAngles = new Vector3(0, 0, 0);
  }

  //private void facePlayer() {
  //  if (theEnemy.transform.position == (-1* (playerPos))) {

  //  }
  //}


  public void OnDisable() {

    scoreEnemy += 100;
    //print(scoreEnemy);

  }






  ////MOVEMENT FOR ENEMY

  //Co-routine for moving units from one space to next >> "end" is the destination
  protected IEnumerator movement(Vector3 end) {
    //finds difference between current and end parameter (using square magnitude for efficiency)
    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    //While the distance is greater than a small number (Epsilon is almost zero)
    while (sqrRemainingDistance > float.Epsilon) {

      //new position proportionally closer to the end, based on move speed
      Vector3 newPos = Vector3.MoveTowards(rigid.position, end, moveSpeed /*inverseMoveSpeed*/ * Time.deltaTime);

      counter++;
      if (counter >= 3) {
        end = playerPos;
      }


      //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
      rigid.MovePosition(newPos);

      //Recalculate the remaining distance after moving.
      sqrRemainingDistance = (transform.position - end).sqrMagnitude;

      //Return and loop until sqrRemainingDistance is close enough to zero to end the function
      yield return null;
    }

  }


  //public float getScore(float f) {
  //  scoreEnemy = f;
  //  return scoreEnemy;
  //}













}
