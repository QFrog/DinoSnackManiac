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
    }
}
