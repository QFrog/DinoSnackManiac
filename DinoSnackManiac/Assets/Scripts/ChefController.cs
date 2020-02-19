using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefController : MonoBehaviour
{
    public Transform target;
    public GameObject cookieRefill;
    public float fallSpeed = 8.0f;
    public float spinSpeed = 250.0f;
    public float speed = 3;

    public Transform cookieLoc;
    private Rigidbody2D cookieGrav;
    Vector3 start;
    bool there;
    float cookieTimer;
    int count;

    void Start()
    {
        //set the starting location to return to
        start = transform.position;
    }

    private void Update()
    {
        // remember, 10 - 5 is 5, so target - position is always your direction.
        Vector3 dir = target.position - transform.position;

        // magnitude is the total length of a vector.
        // getting the magnitude of the direction gives us the amount left to move
        float dist = dir.magnitude;

        // this makes the length of dir 1 so that you can multiply by it.
        dir = dir.normalized;

        // the amount we can move this frame
        float move = speed * Time.deltaTime;

        // limit our move to what we can travel.
        if (move > dist) move = dist;

        // apply the movement to the object.
        transform.Translate(dir * move);

        //reset position
    }
    void FixedUpdate()
    {
        if (transform.position == target.position)
        {
            there = true;
            StartCoroutine(waiter());
        }
        if (count == Random.Range(600, 2400))
        {
            if(transform.position.x > 8.5 || transform.position.x < -8.5)
            {

            }
            else
            {
                Debug.Log("Spawning cookie");
                CookieDrop();
            }
            count = 0;
        }
        if (count > 100)
        {
            count = 0;
        }
        count++;
        //Debug.Log(count);
    }
    void CookieDrop()
    { 
        GameObject droppedCookie = Instantiate(cookieRefill, transform.position, transform.rotation);
    }
    IEnumerator waiter()
    {
        //Wait for 4 seconds
        if (there == true)
        {
            yield return new WaitForSecondsRealtime(2);
            transform.position = start;
            there = false;
        }
    }
}