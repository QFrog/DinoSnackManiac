using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    private Rigidbody2D cookieBody;
    private Transform cookieLoc;
    private Animator anim;
    int count;
    float random;
    void Start()
    {
        anim = GetComponent<Animator>();
        cookieLoc = GetComponent<Transform>();
        cookieBody = GetComponent<Rigidbody2D>();
        cookieBody.constraints = RigidbodyConstraints2D.None;
    }
    void FixedUpdate()
    {
        random = Random.Range(2.0f, -3.8f);
        if (cookieLoc.position.y > (random - 0.1) && cookieLoc.position.y < (random + 0.1))
        {
            Debug.Log("Stopping cookie");
            cookieBody.isKinematic = false;
            cookieBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            anim.SetBool("landed", true);
        }
        if (cookieLoc.position.y < -4)
        {
            Debug.Log("Stopping cookie that went past");
            cookieBody.isKinematic = false;
            cookieLoc.transform.position = new Vector2(cookieLoc.position.x, -4);
            cookieBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            //anim.SetBool("landed", true);
        }
        count++;
        //Debug.Log(count);
    }
}
