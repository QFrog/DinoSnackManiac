using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour{

  public float moveSpeed = 0.5f;
  public LayerMask collisionLayer;

  private BoxCollider2D boxCollider;
  private Rigidbody2D rigid;
  private float inverseMoveSpeed; //used for efficiency 

  public GameObject player;



  //Protected virtual functions can be overriden by inheriting classes
  protected virtual void Start() {

    //getting component references
    boxCollider = GetComponent<BoxCollider2D>();
    rigid = GetComponent<Rigidbody2D>();

    //storing reciprocal of move speed we can use it to multiply instead of dividing (efficient)
    inverseMoveSpeed = 1f / moveSpeed;


  }

  public void Update() {
    //gets player location
    Vector3 playerPos = player.transform.position;
    print(playerPos);
    //calls movements
    StartCoroutine(movement(playerPos));
  }











  ////MOVEMENT FOR ENEMY

  ////takes in x direction, y direction, and raycast to check for collision
  //protected bool Move(int xDir, int yDir, out RaycastHit2D hit) {

  //  //Get starting pos
  //  Vector2 start = transform.position;
  //  //

  //  //check if something was hit
  //  if (hit.transform == null) {
  //    //if nothing was hit, start movement
  //    StartCoroutine(movement(end));


  //    return true;
  //  }

  //  //something was hit, don't move
  //  return false;

  //}




  //Co-routine for moving units from one space to next >> "end" is the destination
  protected IEnumerator movement(Vector3 end) {
    //finds difference between current and end parameter (using square magnitude for efficiency)
    float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

    //While the distance is greater than a small number (Epsilon is almost zero)
    while (sqrRemainingDistance > float.Epsilon) {

      //new position proportionally closer to the end, based on move speed
      Vector3 newPos = Vector3.MoveTowards(rigid.position, end, inverseMoveSpeed * Time.deltaTime);

      //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
      rigid.MovePosition(newPos);

      //Recalculate the remaining distance after moving.
      sqrRemainingDistance = (transform.position - end).sqrMagnitude;

      //Return and loop until sqrRemainingDistance is close enough to zero to end the function
      yield return null;
    }



    
  }















}
