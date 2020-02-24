using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    bool facingRight = true;
    public Vector3 playerLocation; //I'm using this for enemy tracking
    Vector3 change;
    public Camera cam;
    public GameObject GameMan;
    public GameObject death;
    public GameObject death2;
    public Image cross;

  private Rigidbody2D rb2d;
  private SpriteRenderer dino;
  private Variables ammo;
  private Animator anim;
  private Animation animTest;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dino = GetComponent<SpriteRenderer>();
        ammo = GameMan.GetComponent<Variables>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

    var cameraRect = new Rect(
     bottomLeft.x,
     bottomLeft.y,
     topRight.x - bottomLeft.x,
     topRight.y - bottomLeft.y);

    transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
       Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax), transform.position.z);

    if (delta.x >= 0 && !facingRight) { // mouse is on right side of player
      dino.flipX = true; // activate look right some other way;
      facingRight = true;
    }
    else if (delta.x < 0 && facingRight) { // mouse is on left side
      dino.flipX = false; // activate look right some other way
                          // activate looking left
      facingRight = false;
    }
    playerMovement();
  }
  void FixedUpdate() {
    anim.SetBool("Walking", true);
    float moveHorizontonal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector2 movement = new Vector2(moveHorizontonal, moveVertical);
    rb2d.velocity = movement * speed;

  }
  public void playerMovement() {
    if (transform.position.y <= 2) {
      // allowed to move
    }
    else {
      Vector3 newPosition = new Vector3(transform.position.x, 2, transform.position.z);
      transform.position = newPosition;
    }
    if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) {
      anim.SetBool("Idle", false);
      anim.SetBool("Walking", true);
      
      //print("Walking is true");
    }
    else {
      anim.SetBool("Walking", false);
      // print("Walking is false");
    }
    if (Input.GetButtonDown("Fire1")) {
      anim.SetBool("Throwing", true);
    }
    else {
      anim.SetBool("Throwing", false);
    }
  }
  void OnTriggerEnter2D(Collider2D coll) {

    if (coll.gameObject.tag == "ammo") {
      ammo.cookieAmmo1 += 10;
      ammo.cookieText1.text = ammo.cookieAmmo1.ToString();
      ammo.cookieAmmo2 += 10;
      ammo.cookieText2.text = ammo.cookieAmmo2.ToString();
      ammo.cookieAmmo3 += 10;
      ammo.cookieText3.text = ammo.cookieAmmo3.ToString();
      Destroy(coll.gameObject);
    }
    if (coll.gameObject.tag == "enemy" || coll.gameObject.tag == "enemy1" || coll.gameObject.tag == "enemy2") {
            Time.timeScale = 0;
            cross.enabled = false;
            death.SetActive(true);
            death2.SetActive(true);
            //SceneManager.LoadScene("GameOver");
        }
    }
}
