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
  public Vector3 playerPos;
  public static int scoreEnemy = 0;

  public bool enemyHit = false;


  //Protected virtual functions can be overriden by inheriting classes
  protected virtual void Start() {



    //getting component references
    boxCollider = GetComponent<BoxCollider2D>();
    rigid = GetComponent<Rigidbody2D>();

    //storing reciprocal of move speed we can use it to multiply instead of dividing (efficient)
    inverseMoveSpeed = 1f / moveSpeed;

    // GameObject thePlayer = GameObject.Find("PlayerDino");
    //PlayerController playerL = thePlayer.GetComponent<PlayerController>();
    //playerPos = playerL.playerLocation;

  }



  public void FixedUpdate() {




    //gets player location
    //finds the object named PlayerDino
    GameObject thePlayer = GameObject.Find("PlayerDino");

    PlayerController playerL = thePlayer.GetComponent<PlayerController>();
    playerPos = playerL.playerLocation;
    //calls movements
    StartCoroutine(movement(playerPos));
    //calls the standup function
    standUp();


  }

  //keeps players and enemies from spinning
  private void standUp() {
    transform.localEulerAngles = new Vector3(0, 0, 0);
  }


  public void OnDisable() {
    print("I have brain damage");
    scoreEnemy += 100;
    // getScore(100);
    //GameObject theEnemy = GameObject.Find("GameManager");

    //GameManager eScore = theEnemy.GetComponent<GameManager>();
    //scoreEnemy = eScore.score;
    //print(scoreEnemy);
    print(scoreEnemy);

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
