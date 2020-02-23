using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieInteraction : MonoBehaviour {

  private GameObject cookieType;
  private GameObject cookieType1;
  private GameObject cookieType2;

  private Rigidbody2D rigidEnemy;

  public Animator aClone = new Animator();

  private float timer = 10;

  IEnumerator waitPlz(float time, GameObject enemy) {
    yield return new WaitForSeconds(time);
   // print("waiting");
    Destroy(enemy);
    Destroy(this.gameObject);
  }



  void OnTriggerEnter2D(Collider2D coll) {

    

    if (coll.gameObject.tag == "enemy" && this.gameObject.tag == "ammo2") {
      //enemy.rigid.AddForce(Vector3.up * 1000);
      aClone = coll.GetComponent<Animator>();
      aClone.SetBool("explosion", true);
      StartCoroutine(waitPlz((.3f), coll.gameObject));

      //Destroy(coll.gameObject);
      //Destroy(this.gameObject);
    }
    else if (coll.gameObject.tag == "enemy1" && this.gameObject.tag == "ammo3") {
      //enemy.rigid.AddForce(Vector3.up * 1000);
      aClone = coll.GetComponent<Animator>();
      aClone.SetBool("explosion", true);
      StartCoroutine(waitPlz((.3f), coll.gameObject));
    
      //Destroy(coll.gameObject);
      //Destroy(this.gameObject);
    }
    else if (coll.gameObject.tag == "enemy2" && this.gameObject.tag == "ammo1") {
     //rigidE.AddForce(Vector3.up * 1000);
      aClone = coll.GetComponent<Animator>();
      aClone.SetBool("explosion", true);
      StartCoroutine(waitPlz((.3f),coll.gameObject));
  
      //Destroy(coll.gameObject);
      //Destroy(this.gameObject);
    }


  }
}
