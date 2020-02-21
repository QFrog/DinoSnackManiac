using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    private Rigidbody2D cookieBody;
    private Transform cookieLoc;
    int count;
    int random;
    void Start()
    {
        cookieLoc = GetComponent<Transform>();
        cookieBody = GetComponent<Rigidbody2D>();
        cookieBody.constraints = RigidbodyConstraints2D.None;
    }
    void Update()
    {
        random = Random.Range(2, -4);
        if (cookieLoc.position.y > (random - 0.1) && cookieLoc.position.y < (random + 0.1))
        {
            //Debug.Log("Stopping cookie");
            cookieBody.isKinematic = false;
            cookieBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        count++;
        //Debug.Log(count);
    }
}
