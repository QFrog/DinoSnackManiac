using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieInteraction : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("roating cookie");
        transform.Rotate(0, 0, 9999 * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "enemy")
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
public class CookieInteraction : MonoBehaviour {

  private GameObject cookieType;
  private GameObject cookieType1;
  private GameObject cookieType2;

  private void Start() {

  }

  void OnTriggerEnter2D(Collider2D coll) {

    if (coll.gameObject.tag == "enemy" && this.gameObject.tag == "ammo2") {
      Destroy(coll.gameObject);
      Destroy(this.gameObject);
    }
    else if (coll.gameObject.tag == "enemy1" && this.gameObject.tag == "ammo3") {
      Destroy(coll.gameObject);
      Destroy(this.gameObject);
    }
    else if (coll.gameObject.tag == "enemy2" && this.gameObject.tag == "ammo1") {
      Destroy(coll.gameObject);
      Destroy(this.gameObject);
    }


  }
}
