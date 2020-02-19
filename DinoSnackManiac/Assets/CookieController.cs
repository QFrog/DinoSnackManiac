using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    Rigidbody2D cookieGrav;
    Transform cookieLoc;
    int count;
    int random;
    void Start()
    {
        cookieLoc = GetComponent<Transform>();
        cookieGrav = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        random = Random.Range(2, -4);
        if (cookieLoc.position.y > (random - 0.1) && cookieLoc.position.y < (random + 0.1))
        {
            //Debug.Log("Stopping cookie");
            cookieGrav.isKinematic = false;
            cookieGrav.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        count++;
        //Debug.Log(count);
    }
}
